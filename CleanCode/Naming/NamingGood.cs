namespace CleanCode.Naming.Good
{
    /// <summary>
    /// GOOD EXAMPLE: Clear, descriptive naming makes code self-documenting
    /// </summary>
    public class CustomerAccount
    {
        // Good: Descriptive names that reveal intent
        private int accountBalance;
        private string customerEmailAddress;
        
        // Good: Clear collection names
        private List<Order> activeOrders;
        private Dictionary<string, Customer> customersByEmail;
        
        // Good: Full words instead of abbreviations
        private int numberOfItems;
        private string errorMessage;
        private DateTime createdAt;
        
        // Good: Private fields with underscore prefix (C# convention)
        private readonly string _databaseConnectionString;
        private readonly int _maxRetryAttempts;
        
        // Good: Meaningful class names
        public class CustomerRegistrationRequest { }
        public class OrderConfirmationEmail { }
        
        // Good: Pronounceable and searchable
        private DateTime createdTimestamp;
        private DateTime lastModifiedTimestamp;
        
        // Good: Method names that clearly describe actions
        public void CalculateTotalOrderPrice(List<OrderItem> items)
        {
            decimal totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.Price * item.Quantity;
            }
        }
        
        // Good: Named constants instead of magic numbers
        private const int MaxLoginAttempts = 5;
        private const int SessionTimeoutInMinutes = 30;
        private const decimal TaxRate = 0.08m;
        
        public bool HasExceededLoginAttempts(int attemptCount)
        {
            return attemptCount >= MaxLoginAttempts;
        }
        
        // Good: Clear boolean names that read like questions
        private bool isActive;
        private bool hasValidSubscription;
        private bool canProcessPayments;
        
        public bool IsEligibleForDiscount(Customer customer)
        {
            return customer.HasValidSubscription && customer.TotalPurchases > 1000;
        }
        
        // Good: Consistent naming throughout
        public Customer GetCustomerById(int customerId) { return null; }
        public Order GetOrderById(int orderId) { return null; }
        public Product GetProductById(int productId) { return null; }
        
        // All use the same verb "Get" for retrieval operations
        
        // Good: Domain-specific names
        public class ShoppingCart
        {
            public List<CartItem> Items { get; set; }
            public decimal Subtotal { get; set; }
            public decimal ShippingCost { get; set; }
            public decimal TaxAmount { get; set; }
            public decimal GrandTotal { get; set; }
            
            public void AddItem(Product product, int quantity)
            {
                var cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = quantity
                };
                Items.Add(cartItem);
            }
            
            public void RemoveItem(int productId)
            {
                var itemToRemove = Items.FirstOrDefault(i => i.ProductId == productId);
                if (itemToRemove != null)
                {
                    Items.Remove(itemToRemove);
                }
            }
            
            public void ClearCart()
            {
                Items.Clear();
            }
        }
    }
    
    // Supporting classes with good names
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
    }
    
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
    
    public class Customer
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public bool HasValidSubscription { get; set; }
        public decimal TotalPurchases { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
