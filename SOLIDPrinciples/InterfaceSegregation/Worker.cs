namespace SOLIDPrinciples.InterfaceSegregation.Good
{
    /// <summary>
    /// GOOD: Small, focused interfaces
    /// </summary>
    public interface IWorkable
    {
        void Work();
    }

    public interface IEatable
    {
        void Eat();
    }

    public interface ISleepable
    {
        void Sleep();
    }

    public interface IBreakable
    {
        void TakeBreak();
    }

    public interface IPayable
    {
        void GetPaid();
    }

    /// <summary>
    /// Human worker implements all interfaces it needs
    /// </summary>
    public class HumanWorker : IWorkable, IEatable, ISleepable, IBreakable, IPayable
    {
        public string Name { get; set; }

        public HumanWorker(string name)
        {
            Name = name;
        }

        public void Work()
        {
            Console.WriteLine($"{Name} is working");
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating lunch");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }

        public void TakeBreak()
        {
            Console.WriteLine($"{Name} is taking a break");
        }

        public void GetPaid()
        {
            Console.WriteLine($"{Name} received salary");
        }
    }

    /// <summary>
    /// Robot only implements interfaces it needs - no forced empty implementations!
    /// </summary>
    public class RobotWorker : IWorkable, IBreakable
    {
        public string SerialNumber { get; set; }

        public RobotWorker(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public void Work()
        {
            Console.WriteLine($"Robot {SerialNumber} is working");
        }

        public void TakeBreak()
        {
            Console.WriteLine($"Robot {SerialNumber} is recharging batteries");
        }

        // No Eat(), Sleep(), or GetPaid() - robots don't need these!
    }

    /// <summary>
    /// Segregated printer interfaces
    /// </summary>
    public interface IPrinter
    {
        void Print(string document);
    }

    public interface IScanner
    {
        void Scan(string document);
    }

    public interface IFax
    {
        void Fax(string document);
    }

    public interface IPhotocopy
    {
        void Photocopy(string document);
    }

    /// <summary>
    /// All-in-one printer implements all interfaces
    /// </summary>
    public class AllInOnePrinter : IPrinter, IScanner, IFax, IPhotocopy
    {
        public void Print(string document)
        {
            Console.WriteLine($"All-in-one: Printing {document}");
        }

        public void Scan(string document)
        {
            Console.WriteLine($"All-in-one: Scanning {document}");
        }

        public void Fax(string document)
        {
            Console.WriteLine($"All-in-one: Faxing {document}");
        }

        public void Photocopy(string document)
        {
            Console.WriteLine($"All-in-one: Photocopying {document}");
        }
    }

    /// <summary>
    /// Simple printer only implements what it can do - no exceptions thrown!
    /// </summary>
    public class SimplePrinter : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Simple printer: Printing {document}");
        }
        
        // No Scan, Fax, or Photocopy - and that's perfectly fine!
    }

    /// <summary>
    /// Scanner-Printer only implements what it supports
    /// </summary>
    public class ScannerPrinter : IPrinter, IScanner
    {
        public void Print(string document)
        {
            Console.WriteLine($"Scanner-Printer: Printing {document}");
        }

        public void Scan(string document)
        {
            Console.WriteLine($"Scanner-Printer: Scanning {document}");
        }
    }

    /// <summary>
    /// Example demonstrating Interface Segregation Principle
    /// </summary>
    public class InterfaceSegregationExample
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=== Worker Example ===");
            
            // Human worker
            var human = new HumanWorker("John");
            human.Work();
            human.Eat();
            human.Sleep();
            human.GetPaid();

            Console.WriteLine();

            // Robot worker - only uses methods it needs
            var robot = new RobotWorker("R2D2");
            robot.Work();
            robot.TakeBreak();
            // No Eat() or Sleep() or GetPaid() - doesn't need them!

            Console.WriteLine("\n=== Printer Example ===");

            // Simple printer
            IPrinter simplePrinter = new SimplePrinter();
            simplePrinter.Print("Document1.pdf");

            // All-in-one printer
            var allInOne = new AllInOnePrinter();
            allInOne.Print("Document2.pdf");
            allInOne.Scan("Document3.pdf");
            allInOne.Photocopy("Document4.pdf");

            // Scanner-Printer
            var scannerPrinter = new ScannerPrinter();
            scannerPrinter.Print("Document5.pdf");
            scannerPrinter.Scan("Document6.pdf");

            // Benefits:
            // 1. No NotImplementedException
            // 2. Each class only implements what it needs
            // 3. Easy to add new device types
            // 4. Clear contracts for each capability
        }
    }
}
