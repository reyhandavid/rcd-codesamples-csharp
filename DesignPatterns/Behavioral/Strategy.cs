namespace DesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// Strategy interface for compression algorithms
    /// </summary>
    public interface ICompressionStrategy
    {
        byte[] Compress(byte[] data);
        byte[] Decompress(byte[] data);
        string GetAlgorithmName();
    }

    /// <summary>
    /// ZIP compression strategy
    /// </summary>
    public class ZipCompressionStrategy : ICompressionStrategy
    {
        public byte[] Compress(byte[] data)
        {
            Console.WriteLine($"Compressing {data.Length} bytes using ZIP algorithm...");
            // Simulated compression
            return data; // In real implementation, would return compressed data
        }

        public byte[] Decompress(byte[] data)
        {
            Console.WriteLine($"Decompressing using ZIP algorithm...");
            return data;
        }

        public string GetAlgorithmName() => "ZIP";
    }

    /// <summary>
    /// RAR compression strategy
    /// </summary>
    public class RarCompressionStrategy : ICompressionStrategy
    {
        public byte[] Compress(byte[] data)
        {
            Console.WriteLine($"Compressing {data.Length} bytes using RAR algorithm (higher compression ratio)...");
            return data;
        }

        public byte[] Decompress(byte[] data)
        {
            Console.WriteLine($"Decompressing using RAR algorithm...");
            return data;
        }

        public string GetAlgorithmName() => "RAR";
    }

    /// <summary>
    /// GZIP compression strategy
    /// </summary>
    public class GzipCompressionStrategy : ICompressionStrategy
    {
        public byte[] Compress(byte[] data)
        {
            Console.WriteLine($"Compressing {data.Length} bytes using GZIP algorithm (faster)...");
            return data;
        }

        public byte[] Decompress(byte[] data)
        {
            Console.WriteLine($"Decompressing using GZIP algorithm...");
            return data;
        }

        public string GetAlgorithmName() => "GZIP";
    }

    /// <summary>
    /// Context class that uses compression strategies.
    /// The algorithm can be changed at runtime.
    /// </summary>
    public class FileCompressor
    {
        private ICompressionStrategy _strategy;

        public FileCompressor(ICompressionStrategy strategy)
        {
            _strategy = strategy;
        }

        // Strategy can be changed at runtime
        public void SetStrategy(ICompressionStrategy strategy)
        {
            _strategy = strategy;
            Console.WriteLine($"Compression strategy changed to: {strategy.GetAlgorithmName()}");
        }

        public byte[] CompressFile(byte[] fileData)
        {
            Console.WriteLine($"Using {_strategy.GetAlgorithmName()} compression strategy");
            return _strategy.Compress(fileData);
        }

        public byte[] DecompressFile(byte[] compressedData)
        {
            Console.WriteLine($"Using {_strategy.GetAlgorithmName()} decompression strategy");
            return _strategy.Decompress(compressedData);
        }
    }

    /// <summary>
    /// Example usage of Strategy Pattern
    /// </summary>
    public class StrategyPatternExample
    {
        public static void RunExample()
        {
            Console.WriteLine("=== Strategy Pattern Example ===\n");

            var fileData = new byte[1024]; // Simulated file data

            // Start with ZIP compression
            var compressor = new FileCompressor(new ZipCompressionStrategy());
            var compressed = compressor.CompressFile(fileData);

            // Switch to RAR for better compression ratio
            Console.WriteLine("\nSwitching strategy...");
            compressor.SetStrategy(new RarCompressionStrategy());
            compressed = compressor.CompressFile(fileData);

            // Switch to GZIP for faster processing
            Console.WriteLine("\nSwitching strategy again...");
            compressor.SetStrategy(new GzipCompressionStrategy());
            compressed = compressor.CompressFile(fileData);
            compressor.DecompressFile(compressed);

            // Benefits demonstrated:
            // 1. Easy to add new compression algorithms
            // 2. Can switch algorithms at runtime
            // 3. Each algorithm is encapsulated in its own class
            // 4. No conditionals (if/switch) in the context class
        }
    }
}
