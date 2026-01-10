namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// Gold customer discount implementation.
    /// </summary>
    public class GoldCustomerDiscount : IDiscountStrategy
    {
        private const decimal DiscountPercentage = 0.20m; // 20%

        public string Description => "Gold Customer (20% discount)";

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountPercentage;
        }
    }
}
