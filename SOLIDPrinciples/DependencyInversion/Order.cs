namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// Order entity - domain model
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
