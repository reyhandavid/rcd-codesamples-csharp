namespace CleanCode.ErrorHandling.Good
{
    /// <summary>
    /// Custom exception for domain-specific errors
    /// </summary>
    public class OrderProcessingException : Exception
    {
        public string OrderId { get; }
        
        public OrderProcessingException(string orderId, string message) 
            : base(message)
        {
            OrderId = orderId;
        }
        
        public OrderProcessingException(string orderId, string message, Exception innerException)
            : base(message, innerException)
        {
            OrderId = orderId;
        }
    }
    
    public class InsufficientFundsException : Exception
    {
        public decimal RequiredAmount { get; }
        public decimal AvailableAmount { get; }
        
        public InsufficientFundsException(decimal required, decimal available)
            : base($"Insufficient funds. Required: ${required}, Available: ${available}")
        {
            RequiredAmount = required;
            AvailableAmount = available;
        }
    }
    
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        
        public ValidationException(List<string> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }
    }
    
    /// <summary>
    /// GOOD EXAMPLE: Clean error handling practices
    /// </summary>
    public class ErrorHandlingGood
    {
        // Good: Use exceptions instead of return codes
        public void ProcessOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException("Order ID cannot be null or empty", nameof(orderId));
            }
            
            try
            {
                // Process order logic
                Console.WriteLine($"Processing order {orderId}");
            }
            catch (Exception ex)
            {
                // Wrap with domain-specific exception providing context
                throw new OrderProcessingException(
                    orderId, 
                    $"Failed to process order {orderId}", 
                    ex);
            }
        }
        
        // Good: Log exceptions and handle appropriately
        public void SaveData(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    throw new ArgumentException("Data cannot be null or empty", nameof(data));
                }
                
                // Save data to database
                Console.WriteLine("Data saved successfully");
            }
            catch (IOException ex)
            {
                // Log the error
                LogError("Failed to save data", ex);
                
                // Re-throw or handle appropriately
                throw new InvalidOperationException("Unable to save data to storage", ex);
            }
        }
        
        // Good: Catch specific exceptions
        public void LoadConfiguration(string configPath)
        {
            try
            {
                // Load configuration
                Console.WriteLine($"Loading config from {configPath}");
            }
            catch (FileNotFoundException ex)
            {
                LogError($"Configuration file not found: {configPath}", ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                LogError($"Access denied to configuration file: {configPath}", ex);
                throw;
            }
            catch (FormatException ex)
            {
                LogError("Configuration file format is invalid", ex);
                throw new InvalidOperationException("Invalid configuration format", ex);
            }
        }
        
        // Good: Don't return null - throw exception or return empty object
        public Customer GetCustomerById(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentException("Customer ID must be positive", nameof(customerId));
            }
            
            // If customer not found, throw specific exception
            var customer = FindCustomerInDatabase(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException(customerId);
            }
            
            return customer;
        }
        
        // Good: Alternative - return optional/nullable with explicit check
        public Customer? TryGetCustomerById(int customerId)
        {
            if (customerId <= 0)
            {
                return null; // Null is expected here (try pattern)
            }
            
            return FindCustomerInDatabase(customerId);
        }
        
        // Good: Provide context with exceptions
        public void TransferMoney(string fromAccount, string toAccount, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    $"Transfer amount must be positive. Provided: ${amount}", 
                    nameof(amount));
            }
            
            if (string.IsNullOrEmpty(fromAccount))
            {
                throw new ArgumentException("Source account cannot be empty", nameof(fromAccount));
            }
            
            // Check balance
            decimal balance = GetAccountBalance(fromAccount);
            if (balance < amount)
            {
                throw new InsufficientFundsException(amount, balance);
            }
            
            // Transfer logic...
        }
        
        // Good: Proper resource disposal with using statement
        public string ReadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
            }
            
            try
            {
                // 'using' ensures resources are disposed even if exception occurs
                using var stream = File.OpenRead(filePath);
                using var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (FileNotFoundException ex)
            {
                LogError($"File not found: {filePath}", ex);
                throw;
            }
            catch (IOException ex)
            {
                LogError($"Error reading file: {filePath}", ex);
                throw new InvalidOperationException($"Failed to read file: {filePath}", ex);
            }
        }
        
        // Good: Single return point, throw exceptions for errors
        public void ValidateUser(string username, string password)
        {
            var errors = new List<string>();
            
            if (string.IsNullOrEmpty(username))
            {
                errors.Add("Username is required");
            }
            
            if (string.IsNullOrEmpty(password))
            {
                errors.Add("Password is required");
            }
            else if (password.Length < 8)
            {
                errors.Add("Password must be at least 8 characters");
            }
            
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            
            // Validation passed - continue with business logic
        }
        
        // Good: Specific exception handling
        public int ParseInteger(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (FormatException ex)
            {
                LogError($"Invalid integer format: {value}", ex);
                throw new ArgumentException($"Cannot parse '{value}' as integer", nameof(value), ex);
            }
            catch (OverflowException ex)
            {
                LogError($"Integer overflow: {value}", ex);
                throw new ArgumentException($"Value '{value}' is too large", nameof(value), ex);
            }
        }
        
        // Good: Fail fast - validate input early
        public decimal CalculateDiscount(decimal price, decimal discountPercentage)
        {
            // Validate inputs immediately
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative", nameof(price));
            }
            
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException(
                    "Discount percentage must be between 0 and 100", 
                    nameof(discountPercentage));
            }
            
            return price * (discountPercentage / 100);
        }
        
        // Helper methods
        private void LogError(string message, Exception ex)
        {
            Console.WriteLine($"ERROR: {message}");
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
        
        private Customer? FindCustomerInDatabase(int customerId)
        {
            // Simulated database lookup
            return null;
        }
        
        private decimal GetAccountBalance(string accountNumber)
        {
            // Simulated balance lookup
            return 1000m;
        }
    }
    
    // Supporting classes
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    public class CustomerNotFoundException : Exception
    {
        public int CustomerId { get; }
        
        public CustomerNotFoundException(int customerId)
            : base($"Customer with ID {customerId} was not found")
        {
            CustomerId = customerId;
        }
    }
}
