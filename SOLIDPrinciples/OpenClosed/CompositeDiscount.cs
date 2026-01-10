namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// Combines multiple discount strategies.
    /// This is another extension without modifying the core calculator!
    /// </summary>
    public class CompositeDiscount : IDiscountStrategy
    {
        private readonly List<IDiscountStrategy> _strategies;

        public string Description => "Combined Discounts";

        public CompositeDiscount(params IDiscountStrategy[] strategies)
        {
            _strategies = new List<IDiscountStrategy>(strategies);
        }

        public decimal CalculateDiscount(decimal amount)
        {
            decimal totalDiscount = 0;
            foreach (var strategy in _strategies)
            {
                totalDiscount += strategy.CalculateDiscount(amount);
            }
            return totalDiscount;
        }
    }
}
