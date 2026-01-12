namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// SMS implementation of INotificationService.
    /// Can be swapped with EmailNotificationService without changing high-level code!
    /// </summary>
    public class SmsNotificationService : INotificationService
    {
        private readonly string _apiKey;

        public SmsNotificationService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void SendOrderConfirmation(string recipientEmail, int orderId)
        {
            // In real implementation, would convert email to phone number lookup
            Console.WriteLine($"Sending SMS notification using API key");
            Console.WriteLine($"Message: Your order #{orderId} has been confirmed");
            // SMS-specific implementation details
        }
    }
}
