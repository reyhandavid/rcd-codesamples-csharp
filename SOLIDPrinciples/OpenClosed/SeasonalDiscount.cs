namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// Seasonal discount implementation.
    /// This is a NEW discount type that can be added WITHOUT modifying existing code!
    /// </summary>
    public class SeasonalDiscount : IDiscountStrategy
    {
        private const decimal DiscountPercentage = 0.10m; // 10%

        public string Description => "Seasonal Promotion (10% discount)";

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * DiscountPercentage;
        }
    }
}
