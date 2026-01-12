namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// Abstraction for order persistence.
    /// High-level code depends on this, not on concrete database implementations.
    /// </summary>
    public interface IOrderRepository
    {
        void Save(Order order);
        Order GetById(int id);
    }
}
