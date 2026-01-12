namespace SOLIDPrinciples.SingleResponsibility.Bad
{
    /// <summary>
    /// BAD EXAMPLE: This class violates SRP by having multiple responsibilities.
    /// It handles validation, persistence, email notifications, and logging.
    /// </summary>
    public class UserServiceBad
    {
        public bool CreateUser(string email, string password, string name)
        {
            // Responsibility 1: Validation
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                Console.WriteLine("Invalid email");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters");
                return false;
            }

            // Responsibility 2: Database persistence
            try
            {
                var connectionString = "Server=localhost;Database=Users;";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "INSERT INTO Users (Email, Password, Name) VALUES (@email, @password, @name)",
                        connection);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Responsibility 3: Logging
                Console.WriteLine($"Error: {ex.Message}");
                File.AppendAllText("error.log", $"{DateTime.Now}: {ex.Message}\n");
                return false;
            }

            // Responsibility 4: Email notifications
            try
            {
                var smtpClient = new SmtpClient("smtp.example.com");
                var message = new MailMessage("noreply@example.com", email)
                {
                    Subject = "Welcome!",
                    Body = $"Welcome {name}! Your account has been created."
                };
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }

            return true;
        }

        // More responsibilities could be added: password hashing, user authentication, etc.
    }

    // Pseudo-classes to make the example compile
    class SqlConnection : IDisposable
    {
        public SqlConnection(string connectionString) { }
        public void Open() { }
        public void Dispose() { }
    }

    class SqlCommand
    {
        public SqlCommand(string query, SqlConnection connection) { }
        public SqlParameterCollection Parameters { get; } = new SqlParameterCollection();
        public void ExecuteNonQuery() { }
    }

    class SqlParameterCollection
    {
        public void AddWithValue(string name, string value) { }
    }

    class SmtpClient
    {
        public SmtpClient(string host) { }
        public void Send(MailMessage message) { }
    }

    class MailMessage
    {
        public MailMessage(string from, string to) { }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
