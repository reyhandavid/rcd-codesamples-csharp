namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// GOOD EXAMPLE: High-level OrderProcessor depends only on abstractions.
    /// It doesn't know or care about SQL, MongoDB, Email, or SMS.
    /// Dependencies are injected, making the class flexible and testable.
    /// </summary>
    public class OrderProcessor
    {
        private readonly IOrderRepository _orderRepository;
        private readonly INotificationService _notificationService;

        // Dependencies are injected - Dependency Injection pattern
        public OrderProcessor(IOrderRepository orderRepository, INotificationService notificationService)
        {
            _orderRepository = orderRepository;
            _notificationService = notificationService;
        }

        public void ProcessOrder(Order order)
        {
            // High-level business logic - no knowledge of low-level details
            ValidateOrder(order);
            _orderRepository.Save(order);
            _notificationService.SendOrderConfirmation(order.CustomerEmail, order.Id);
            
            Console.WriteLine($"Order {order.Id} processed successfully");
        }

        private void ValidateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            
            if (string.IsNullOrWhiteSpace(order.CustomerEmail))
                throw new ArgumentException("Customer email is required");

            if (order.Total <= 0)
                throw new ArgumentException("Order total must be greater than zero");
        }
    }

    /// <summary>
    /// Example usage demonstrating Dependency Inversion Principle
    /// </summary>
    public class OrderProcessingExample
    {
        public static void RunExample()
        {
            var order = new Order
            {
                Id = 12345,
                CustomerEmail = "customer@example.com",
                Total = 99.99m,
                OrderDate = DateTime.Now
            };

            // Configuration 1: SQL Database + Email
            Console.WriteLine("=== Configuration 1: SQL + Email ===");
            var sqlProcessor = new OrderProcessor(
                new SqlOrderRepository("Server=localhost;Database=Orders;"),
                new EmailNotificationService("smtp.example.com")
            );
            sqlProcessor.ProcessOrder(order);

            // Configuration 2: MongoDB + SMS (swapped without changing OrderProcessor!)
            Console.WriteLine("\n=== Configuration 2: MongoDB + SMS ===");
            var mongoProcessor = new OrderProcessor(
                new MongoOrderRepository("mongodb://localhost:27017"),
                new SmsNotificationService("api-key-123")
            );
            mongoProcessor.ProcessOrder(order);

            // The high-level OrderProcessor class didn't change at all!
            // We just provided different implementations of the abstractions.
        }
    }
}
