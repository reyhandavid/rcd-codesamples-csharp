namespace SOLIDPrinciples.SingleResponsibility.Good
{
    /// <summary>
    /// Handles email notifications.
    /// Responsibility: Sending emails only.
    /// </summary>
    public class EmailService
    {
        private readonly string _smtpServer;

        public EmailService(string smtpServer)
        {
            _smtpServer = smtpServer;
        }

        public void SendWelcomeEmail(string toEmail, string userName)
        {
            SendEmail(
                toEmail,
                "Welcome!",
                $"Welcome {userName}! Your account has been created successfully."
            );
        }

        private void SendEmail(string to, string subject, string body)
        {
            // In a real application, this would use an email library
            // This is simplified for demonstration.
            Console.WriteLine($"Sending email to {to}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
            
            // Actual implementation would be:
            // using var smtpClient = new SmtpClient(_smtpServer);
            // var message = new MailMessage("noreply@example.com", to, subject, body);
            // smtpClient.Send(message);
        }
    }
}
