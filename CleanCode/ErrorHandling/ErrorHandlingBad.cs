namespace CleanCode.ErrorHandling.Bad
{
    /// <summary>
    /// BAD EXAMPLE: Poor error handling practices
    /// </summary>
    public class ErrorHandlingBad
    {
        // Bad: Using return codes instead of exceptions
        public int ProcessOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                return -1; // Error code - what does -1 mean?
            
            // More logic...
            // Simulated error condition
            bool hasError = orderId.Length < 5;
            if (hasError)
                return -2; // Different error code
            
            return 0; // Success - forces caller to check return value
        }
        
        // Bad: Swallowing exceptions
        public void SaveData(string data)
        {
            try
            {
                // Save data to database
            }
            catch (Exception)
            {
                // Doing nothing - error is hidden!
            }
        }
        
        // Bad: Catching generic Exception
        public void LoadConfiguration()
        {
            try
            {
                // Load config
            }
            catch (Exception ex)
            {
                // Too broad - catches everything including critical errors
                Console.WriteLine("Error");
            }
        }
        
        // Bad: Returning null
        public Customer GetCustomer(int id)
        {
            if (id <= 0)
                return null; // Caller must check for null
            
            // If customer not found
            return null; // Why is it null? Not found? Error?
        }
        
        // Bad: No context in exception
        public void TransferMoney(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Invalid"); // What is invalid?
        }
        
        // Bad: Not disposing resources
        public string ReadFile(string path)
        {
            var stream = File.OpenRead(path);
            var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            // Stream and reader are never closed!
            return content;
        }
        
        // Bad: Multiple return points with error codes
        public int ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                return 1;
            
            if (string.IsNullOrEmpty(password))
                return 2;
            
            if (password.Length < 8)
                return 3;
            
            // Business logic mixed with error checking
            return 0;
        }
        
        // Bad: Ignoring specific exception types
        public void ParseData(string data)
        {
            try
            {
                int.Parse(data);
            }
            catch
            {
                // No exception variable - can't log or handle it
            }
        }
    }
    
    public class Customer { }
}
