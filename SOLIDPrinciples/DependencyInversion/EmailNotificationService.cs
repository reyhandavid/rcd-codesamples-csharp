namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// Email implementation of INotificationService.
    /// Low-level detail that depends on the abstraction.
    /// </summary>
    public class EmailNotificationService : INotificationService
    {
        private readonly string _smtpServer;

        public EmailNotificationService(string smtpServer)
        {
            _smtpServer = smtpServer;
        }

        public void SendOrderConfirmation(string recipientEmail, int orderId)
        {
            Console.WriteLine($"Sending email to {recipientEmail} via {_smtpServer}");
            Console.WriteLine($"Subject: Order #{orderId} Confirmation");
            // Email-specific implementation details
        }
    }
}
