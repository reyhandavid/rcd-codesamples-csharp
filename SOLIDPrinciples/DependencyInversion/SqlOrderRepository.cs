namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// SQL implementation of IOrderRepository.
    /// Low-level detail that depends on the abstraction.
    /// </summary>
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public SqlOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(Order order)
        {
            Console.WriteLine($"Saving order {order.Id} to SQL database at {_connectionString}");
            // SQL-specific implementation details
        }

        public Order GetById(int id)
        {
            Console.WriteLine($"Retrieving order {id} from SQL database");
            return new Order { Id = id };
        }
    }
}
