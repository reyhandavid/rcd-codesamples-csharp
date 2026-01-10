namespace DesignPatterns.Creational.Factory
{
    /// <summary>
    /// Payment processor abstraction
    /// </summary>
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount, string accountInfo);
        string GetProcessorName();
    }

    /// <summary>
    /// Credit card payment processor
    /// </summary>
    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount, string accountInfo)
        {
            Console.WriteLine($"Processing ${amount} via Credit Card ending in {accountInfo.Substring(accountInfo.Length - 4)}");
            return true;
        }

        public string GetProcessorName() => "Credit Card";
    }

    /// <summary>
    /// PayPal payment processor
    /// </summary>
    public class PayPalProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount, string accountInfo)
        {
            Console.WriteLine($"Processing ${amount} via PayPal account {accountInfo}");
            return true;
        }

        public string GetProcessorName() => "PayPal";
    }

    /// <summary>
    /// Cryptocurrency payment processor
    /// </summary>
    public class CryptoProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount, string accountInfo)
        {
            Console.WriteLine($"Processing ${amount} via Cryptocurrency wallet {accountInfo}");
            return true;
        }

        public string GetProcessorName() => "Cryptocurrency";
    }

    /// <summary>
    /// Factory for creating payment processors.
    /// Encapsulates object creation logic.
    /// </summary>
    public class PaymentProcessorFactory
    {
        public IPaymentProcessor CreateProcessor(string paymentType)
        {
            return paymentType.ToLower() switch
            {
                "creditcard" => new CreditCardProcessor(),
                "paypal" => new PayPalProcessor(),
                "crypto" => new CryptoProcessor(),
                _ => throw new ArgumentException($"Unknown payment type: {paymentType}")
            };
        }

        // Alternative: Factory method with more complex logic
        public IPaymentProcessor CreateProcessorForAmount(decimal amount)
        {
            // Business logic: small amounts use PayPal, large amounts use credit card
            if (amount < 100)
                return new PayPalProcessor();
            else if (amount < 10000)
                return new CreditCardProcessor();
            else
                return new CryptoProcessor();
        }
    }

    /// <summary>
    /// Example usage of Factory Pattern
    /// </summary>
    public class FactoryPatternExample
    {
        public static void RunExample()
        {
            var factory = new PaymentProcessorFactory();

            // Client code doesn't need to know about concrete classes
            IPaymentProcessor processor1 = factory.CreateProcessor("creditcard");
            processor1.ProcessPayment(150.00m, "****1234");

            IPaymentProcessor processor2 = factory.CreateProcessor("paypal");
            processor2.ProcessPayment(50.00m, "user@example.com");

            // Factory can encapsulate complex creation logic
            IPaymentProcessor processor3 = factory.CreateProcessorForAmount(25000.00m);
            Console.WriteLine($"\nFor large amount, selected: {processor3.GetProcessorName()}");
            processor3.ProcessPayment(25000.00m, "0x742d35Cc6634C0532925a3b844Bc9e7595f0bEb");
        }
    }
}
