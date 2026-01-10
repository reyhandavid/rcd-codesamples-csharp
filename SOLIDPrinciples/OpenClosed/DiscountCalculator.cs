namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// GOOD EXAMPLE: This calculator is closed for modification but open for extension.
    /// New discount types can be added without changing this class.
    /// </summary>
    public class DiscountCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;

        public DiscountCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal CalculateDiscount(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative", nameof(amount));
            }

            return _discountStrategy.CalculateDiscount(amount);
        }

        public decimal CalculateFinalPrice(decimal amount)
        {
            var discount = CalculateDiscount(amount);
            return amount - discount;
        }

        public string GetDiscountDescription()
        {
            return _discountStrategy.Description;
        }
    }

    /// <summary>
    /// Example usage demonstrating the Open/Closed Principle
    /// </summary>
    public class DiscountExample
    {
        public static void RunExample()
        {
            decimal orderAmount = 1000m;

            // Regular customer
            var regularCalculator = new DiscountCalculator(new RegularCustomerDiscount());
            Console.WriteLine($"{regularCalculator.GetDiscountDescription()}");
            Console.WriteLine($"Original: ${orderAmount}, Final: ${regularCalculator.CalculateFinalPrice(orderAmount)}");

            // VIP customer
            var vipCalculator = new DiscountCalculator(new VipCustomerDiscount());
            Console.WriteLine($"\n{vipCalculator.GetDiscountDescription()}");
            Console.WriteLine($"Original: ${orderAmount}, Final: ${vipCalculator.CalculateFinalPrice(orderAmount)}");

            // Seasonal + VIP (composite)
            var compositeCalculator = new DiscountCalculator(
                new CompositeDiscount(new VipCustomerDiscount(), new SeasonalDiscount())
            );
            Console.WriteLine($"\nVIP + Seasonal");
            Console.WriteLine($"Original: ${orderAmount}, Final: ${compositeCalculator.CalculateFinalPrice(orderAmount)}");

            // Adding a new discount type? Just create a new class implementing IDiscountStrategy!
            // No need to modify DiscountCalculator or any existing discount classes.
        }
    }
}
