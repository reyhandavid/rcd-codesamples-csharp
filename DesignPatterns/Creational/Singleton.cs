namespace DesignPatterns.Creational.Singleton
{
    /// <summary>
    /// Thread-safe Singleton implementation.
    /// Ensures only one instance of the class exists throughout the application.
    /// </summary>
    public sealed class ConfigurationManager
    {
        // Private static instance - lazy initialization
        private static readonly Lazy<ConfigurationManager> _instance = 
            new Lazy<ConfigurationManager>(() => new ConfigurationManager());

        private readonly Dictionary<string, string> _settings;

        // Private constructor prevents external instantiation
        private ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
            LoadConfiguration();
        }

        // Public static property to access the instance
        public static ConfigurationManager Instance => _instance.Value;

        private void LoadConfiguration()
        {
            // Simulated configuration loading
            Console.WriteLine("Loading configuration (expensive operation)...");
            _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
            _settings["ApiKey"] = "abc123xyz";
            _settings["MaxConnections"] = "100";
        }

        public string GetSetting(string key)
        {
            return _settings.TryGetValue(key, out var value) ? value : null;
        }

        public void SetSetting(string key, string value)
        {
            _settings[key] = value;
        }
    }

    /// <summary>
    /// Alternative Singleton: Eager initialization
    /// Instance is created when class is loaded, not when first accessed
    /// </summary>
    public sealed class Logger
    {
        // Eager initialization - created immediately
        private static readonly Logger _instance = new Logger();

        private readonly string _logFilePath;

        private Logger()
        {
            _logFilePath = "application.log";
            Console.WriteLine("Logger initialized");
        }

        public static Logger Instance => _instance;

        public void Log(string message)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            Console.WriteLine(logEntry);
            // In real implementation: File.AppendAllText(_logFilePath, logEntry + "\n");
        }
    }

    /// <summary>
    /// Example usage of Singleton Pattern
    /// </summary>
    public class SingletonPatternExample
    {
        public static void RunExample()
        {
            Console.WriteLine("=== Singleton Pattern Example ===\n");

            // Get the singleton instance
            var config1 = ConfigurationManager.Instance;
            Console.WriteLine($"Database: {config1.GetSetting("DatabaseConnection")}");

            // Getting the instance again returns the same object
            var config2 = ConfigurationManager.Instance;
            config2.SetSetting("AppName", "My Application");

            // Both references point to the same instance
            Console.WriteLine($"\nconfig1 == config2: {ReferenceEquals(config1, config2)}");
            Console.WriteLine($"AppName from config1: {config1.GetSetting("AppName")}");

            // Logger singleton
            Console.WriteLine("\n=== Logger Singleton ===");
            Logger.Instance.Log("Application started");
            Logger.Instance.Log("Processing request");
            
            // Same instance
            var logger2 = Logger.Instance;
            Console.WriteLine($"Logger instances are same: {ReferenceEquals(Logger.Instance, logger2)}");
        }
    }
}
