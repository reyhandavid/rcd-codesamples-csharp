namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// VIP customer discount implementation.
    /// </summary>
    public class VipCustomerDiscount : IDiscountStrategy
    {
        private const decimal DiscountPercentage = 0.15m; // 15%

        public string Description => "VIP Customer (15% discount)";

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountPercentage;
        }
    }
}
