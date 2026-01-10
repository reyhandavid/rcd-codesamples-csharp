namespace SOLIDPrinciples.DependencyInversion.Good
{
    /// <summary>
    /// MongoDB implementation of IOrderRepository.
    /// Can be swapped with SqlOrderRepository without changing high-level code!
    /// </summary>
    public class MongoOrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public MongoOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(Order order)
        {
            Console.WriteLine($"Saving order {order.Id} to MongoDB at {_connectionString}");
            // MongoDB-specific implementation details
        }

        public Order GetById(int id)
        {
            Console.WriteLine($"Retrieving order {id} from MongoDB");
            return new Order { Id = id };
        }
    }
}
