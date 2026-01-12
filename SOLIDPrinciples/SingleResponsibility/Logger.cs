namespace SOLIDPrinciples.SingleResponsibility.Good
{
    /// <summary>
    /// Handles application logging.
    /// Responsibility: Logging only.
    /// </summary>
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogError(string message, Exception exception = null)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}";
            if (exception != null)
            {
                logEntry += $"\nException: {exception.Message}\nStack Trace: {exception.StackTrace}";
            }

            Console.WriteLine(logEntry);
            
            // In a real application, you might use a logging framework like Serilog or NLog
            // File.AppendAllText(_logFilePath, logEntry + "\n");
        }

        public void LogInfo(string message)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}";
            Console.WriteLine(logEntry);
            // File.AppendAllText(_logFilePath, logEntry + "\n");
        }
    }
}
