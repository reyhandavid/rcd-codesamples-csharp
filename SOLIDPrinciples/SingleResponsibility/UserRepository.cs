namespace SOLIDPrinciples.SingleResponsibility.Good
{
    /// <summary>
    /// Handles user data persistence.
    /// Responsibility: Database operations for users only.
    /// </summary>
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(User user)
        {
            // In a real application, this would use an ORM like Entity Framework
            // or a database library. This is simplified for demonstration.
            
            // Simulated database save
            Console.WriteLine($"Saving user {user.Email} to database...");
            
            // Actual implementation would be:
            // using var connection = new SqlConnection(_connectionString);
            // connection.Open();
            // var command = new SqlCommand("INSERT INTO Users...", connection);
            // command.ExecuteNonQuery();
        }

        public User GetByEmail(string email)
        {
            // Simulated database retrieval
            Console.WriteLine($"Retrieving user {email} from database...");
            return null; // In real code, would return user from database
        }
    }
}
