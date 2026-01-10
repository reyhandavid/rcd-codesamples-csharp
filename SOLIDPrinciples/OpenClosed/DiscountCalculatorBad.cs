namespace SOLIDPrinciples.OpenClosed.Bad
{
    /// <summary>
    /// BAD EXAMPLE: This class violates OCP because every time we need
    /// to add a new discount type, we must modify this class.
    /// </summary>
    public class DiscountCalculatorBad
    {
        public decimal CalculateDiscount(decimal amount, string customerType)
        {
            decimal discount = 0;

            // Every new customer type requires modifying this method
            switch (customerType)
            {
                case "Regular":
                    discount = amount * 0.05m; // 5% discount
                    break;
                case "VIP":
                    discount = amount * 0.15m; // 15% discount
                    break;
                case "Gold":
                    discount = amount * 0.20m; // 20% discount
                    break;
                // What if we need to add Platinum, Silver, Seasonal, etc.?
                // We have to keep modifying this class!
                default:
                    discount = 0;
                    break;
            }

            return discount;
        }

        // As requirements grow, this class becomes harder to maintain
        public decimal CalculateDiscountWithSeasonalBonus(decimal amount, string customerType, bool isSeason)
        {
            decimal discount = CalculateDiscount(amount, customerType);
            
            // More modifications needed for seasonal logic
            if (isSeason)
            {
                discount += amount * 0.05m;
            }

            return discount;
        }
    }
}
