namespace SOLIDPrinciples.OpenClosed.Good
{
    /// <summary>
    /// Abstraction for discount calculation strategies.
    /// New discount types can be added without modifying existing code.
    /// </summary>
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal amount);
        string Description { get; }
    }
}
