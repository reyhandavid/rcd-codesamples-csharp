namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// Regular customer discount implementation.
    /// </summary>
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        private const decimal DiscountPercentage = 0.05m; // 5%

        public string Description => "Regular Customer (5% discount)";

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountPercentage;
        }
    }
}
