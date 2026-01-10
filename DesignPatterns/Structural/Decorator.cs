namespace DesignPatterns.Structural.Decorator
{
    /// <summary>
    /// Component interface - defines the contract
    /// </summary>
    public interface INotification
    {
        void Send(string message);
    }

    /// <summary>
    /// Concrete component - basic notification implementation
    /// </summary>
    public class BasicNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Basic notification: {message}");
        }
    }

    /// <summary>
    /// Base decorator - wraps a notification and delegates to it
    /// </summary>
    public abstract class NotificationDecorator : INotification
    {
        protected readonly INotification _notification;

        protected NotificationDecorator(INotification notification)
        {
            _notification = notification;
        }

        public virtual void Send(string message)
        {
            _notification.Send(message);
        }
    }

    /// <summary>
    /// Concrete decorator - adds email functionality
    /// </summary>
    public class EmailNotificationDecorator : NotificationDecorator
    {
        private readonly string _emailAddress;

        public EmailNotificationDecorator(INotification notification, string emailAddress)
            : base(notification)
        {
            _emailAddress = emailAddress;
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendEmail(message);
        }

        private void SendEmail(string message)
        {
            Console.WriteLine($"📧 Sending email to {_emailAddress}: {message}");
        }
    }

    /// <summary>
    /// Concrete decorator - adds SMS functionality
    /// </summary>
    public class SmsNotificationDecorator : NotificationDecorator
    {
        private readonly string _phoneNumber;

        public SmsNotificationDecorator(INotification notification, string phoneNumber)
            : base(notification)
        {
            _phoneNumber = phoneNumber;
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendSms(message);
        }

        private void SendSms(string message)
        {
            Console.WriteLine($"📱 Sending SMS to {_phoneNumber}: {message}");
        }
    }

    /// <summary>
    /// Concrete decorator - adds Slack functionality
    /// </summary>
    public class SlackNotificationDecorator : NotificationDecorator
    {
        private readonly string _channel;

        public SlackNotificationDecorator(INotification notification, string channel)
            : base(notification)
        {
            _channel = channel;
        }

        public override void Send(string message)
        {
            base.Send(message);
            SendSlackMessage(message);
        }

        private void SendSlackMessage(string message)
        {
            Console.WriteLine($"💬 Sending Slack message to #{_channel}: {message}");
        }
    }

    /// <summary>
    /// Concrete decorator - adds priority marking
    /// </summary>
    public class UrgentNotificationDecorator : NotificationDecorator
    {
        public UrgentNotificationDecorator(INotification notification)
            : base(notification)
        {
        }

        public override void Send(string message)
        {
            string urgentMessage = $"🚨 URGENT: {message}";
            base.Send(urgentMessage);
        }
    }

    /// <summary>
    /// Example usage of Decorator Pattern
    /// </summary>
    public class DecoratorPatternExample
    {
        public static void RunExample()
        {
            Console.WriteLine("=== Decorator Pattern Example ===\n");

            // Basic notification
            Console.WriteLine("1. Basic notification:");
            INotification basic = new BasicNotification();
            basic.Send("Server is running");

            // Add email
            Console.WriteLine("\n2. Basic + Email:");
            INotification withEmail = new EmailNotificationDecorator(
                new BasicNotification(),
                "admin@example.com"
            );
            withEmail.Send("Server is running");

            // Add multiple decorators
            Console.WriteLine("\n3. Basic + Email + SMS:");
            INotification withEmailAndSms = new SmsNotificationDecorator(
                new EmailNotificationDecorator(
                    new BasicNotification(),
                    "admin@example.com"
                ),
                "+1-555-0123"
            );
            withEmailAndSms.Send("Server is running");

            // All decorators + urgent
            Console.WriteLine("\n4. All channels + Urgent:");
            INotification allChannels = new UrgentNotificationDecorator(
                new SlackNotificationDecorator(
                    new SmsNotificationDecorator(
                        new EmailNotificationDecorator(
                            new BasicNotification(),
                            "admin@example.com"
                        ),
                        "+1-555-0123"
                    ),
                    "alerts"
                )
            );
            allChannels.Send("Server is down!");

            // Benefits demonstrated:
            // 1. Can add functionality dynamically at runtime
            // 2. Can combine decorators in any order
            // 3. Single Responsibility - each decorator has one job
            // 4. Open/Closed - can add new decorators without modifying existing code
            // 5. More flexible than inheritance
        }
    }
}
