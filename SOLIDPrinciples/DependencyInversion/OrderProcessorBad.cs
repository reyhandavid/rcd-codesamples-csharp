namespace SOLIDPrinciples.DependencyInversion.Bad
{
    /// <summary>
    /// BAD EXAMPLE: This high-level class directly depends on low-level concrete classes.
    /// It's tightly coupled to specific implementations.
    /// </summary>
    public class OrderProcessorBad
    {
        private readonly SqlDatabase _database;
        private readonly EmailSender _emailSender;

        public OrderProcessorBad()
        {
            // Creating dependencies inside the class - tight coupling!
            _database = new SqlDatabase("Server=localhost;Database=Orders;");
            _emailSender = new EmailSender("smtp.example.com");
        }

        public void ProcessOrder(Order order)
        {
            // High-level business logic is mixed with low-level details
            _database.SaveOrder(order);
            _emailSender.SendOrderConfirmation(order.CustomerEmail, order.Id);
        }

        // Problems:
        // 1. Can't easily switch to a different database (e.g., NoSQL)
        // 2. Can't easily switch to a different notification method (e.g., SMS)
        // 3. Difficult to test - can't mock the database or email sender
        // 4. This class knows too much about implementation details
    }

    // Low-level concrete classes that high-level code depends on
    public class SqlDatabase
    {
        private readonly string _connectionString;

        public SqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SaveOrder(Order order)
        {
            Console.WriteLine($"Saving order {order.Id} to SQL database...");
            // SQL-specific implementation
        }
    }

    public class EmailSender
    {
        private readonly string _smtpServer;

        public EmailSender(string smtpServer)
        {
            _smtpServer = smtpServer;
        }

        public void SendOrderConfirmation(string email, int orderId)
        {
            Console.WriteLine($"Sending email to {email} for order {orderId}...");
            // Email-specific implementation
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Total { get; set; }
    }
}
