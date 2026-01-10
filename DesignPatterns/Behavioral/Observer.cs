namespace DesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Observer interface - subscribers implement this
    /// </summary>
    public interface IObserver
    {
        void Update(string message);
    }

    /// <summary>
    /// Subject interface - publishers implement this
    /// </summary>
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }

    /// <summary>
    /// Concrete Subject - Stock price tracker
    /// </summary>
    public class StockPriceTracker : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private string _stockSymbol;
        private decimal _currentPrice;

        public StockPriceTracker(string stockSymbol)
        {
            _stockSymbol = stockSymbol;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"Observer subscribed to {_stockSymbol}");
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"Observer unsubscribed from {_stockSymbol}");
        }

        public void Notify(string message)
        {
            Console.WriteLine($"\nNotifying {_observers.Count} observers...");
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void SetPrice(decimal newPrice)
        {
            _currentPrice = newPrice;
            Notify($"{_stockSymbol} price updated to ${_currentPrice}");
        }
    }

    /// <summary>
    /// Concrete Observer - Email notification
    /// </summary>
    public class EmailNotifier : IObserver
    {
        private readonly string _emailAddress;

        public EmailNotifier(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        public void Update(string message)
        {
            Console.WriteLine($"  📧 Email sent to {_emailAddress}: {message}");
        }
    }

    /// <summary>
    /// Concrete Observer - SMS notification
    /// </summary>
    public class SmsNotifier : IObserver
    {
        private readonly string _phoneNumber;

        public SmsNotifier(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public void Update(string message)
        {
            Console.WriteLine($"  📱 SMS sent to {_phoneNumber}: {message}");
        }
    }

    /// <summary>
    /// Concrete Observer - Mobile app push notification
    /// </summary>
    public class MobileAppNotifier : IObserver
    {
        private readonly string _userId;

        public MobileAppNotifier(string userId)
        {
            _userId = userId;
        }

        public void Update(string message)
        {
            Console.WriteLine($"  📲 Push notification to user {_userId}: {message}");
        }
    }

    /// <summary>
    /// Example usage of Observer Pattern
    /// </summary>
    public class ObserverPatternExample
    {
        public static void RunExample()
        {
            Console.WriteLine("=== Observer Pattern Example ===\n");

            // Create subject (publisher)
            var appleStock = new StockPriceTracker("AAPL");

            // Create observers (subscribers)
            var emailNotifier = new EmailNotifier("investor@example.com");
            var smsNotifier = new SmsNotifier("+1-555-0123");
            var appNotifier = new MobileAppNotifier("user123");

            // Subscribe observers
            appleStock.Attach(emailNotifier);
            appleStock.Attach(smsNotifier);
            appleStock.Attach(appNotifier);

            // Change stock price - all observers are notified
            appleStock.SetPrice(150.25m);
            appleStock.SetPrice(152.50m);

            // Unsubscribe one observer
            Console.WriteLine("\n--- Unsubscribing SMS notifier ---");
            appleStock.Detach(smsNotifier);

            // Change price again - SMS notifier won't be notified
            appleStock.SetPrice(148.75m);

            // Benefits demonstrated:
            // 1. Loose coupling between subject and observers
            // 2. Dynamic subscription/unsubscription
            // 3. One-to-many notification
            // 4. Easy to add new observer types
        }
    }
}
