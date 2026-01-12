namespace SOLIDPrinciples.InterfaceSegregation.Bad
{
    /// <summary>
    /// BAD EXAMPLE: Fat interface that forces all implementers
    /// to implement methods they don't need
    /// </summary>
    public interface IWorkerBad
    {
        void Work();
        void Eat();
        void Sleep();
        void TakeBreak();
        void GetPaid();
    }

    /// <summary>
    /// Human worker can do all these things
    /// </summary>
    public class HumanWorkerBad : IWorkerBad
    {
        public void Work()
        {
            Console.WriteLine("Human is working");
        }

        public void Eat()
        {
            Console.WriteLine("Human is eating lunch");
        }

        public void Sleep()
        {
            Console.WriteLine("Human is sleeping");
        }

        public void TakeBreak()
        {
            Console.WriteLine("Human is taking a break");
        }

        public void GetPaid()
        {
            Console.WriteLine("Human received salary");
        }
    }

    /// <summary>
    /// PROBLEM: Robot is forced to implement Eat and Sleep even though it doesn't need them!
    /// This violates ISP.
    /// </summary>
    public class RobotWorkerBad : IWorkerBad
    {
        public void Work()
        {
            Console.WriteLine("Robot is working");
        }

        public void Eat()
        {
            // Robots don't eat!
            throw new NotImplementedException("Robots don't eat");
        }

        public void Sleep()
        {
            // Robots don't sleep!
            throw new NotImplementedException("Robots don't sleep");
        }

        public void TakeBreak()
        {
            Console.WriteLine("Robot is recharging");
        }

        public void GetPaid()
        {
            // Robots don't get paid in traditional sense
            throw new NotImplementedException("Robots don't get paid");
        }
    }

    /// <summary>
    /// Another example: Printer interface that's too broad
    /// </summary>
    public interface IMultiFunctionDeviceBad
    {
        void Print(string document);
        void Scan(string document);
        void Fax(string document);
        void Photocopy(string document);
    }

    /// <summary>
    /// All-in-one printer can do everything
    /// </summary>
    public class AllInOnePrinterBad : IMultiFunctionDeviceBad
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }

        public void Scan(string document)
        {
            Console.WriteLine($"Scanning: {document}");
        }

        public void Fax(string document)
        {
            Console.WriteLine($"Faxing: {document}");
        }

        public void Photocopy(string document)
        {
            Console.WriteLine($"Photocopying: {document}");
        }
    }

    /// <summary>
    /// PROBLEM: Simple printer is forced to implement features it doesn't have!
    /// </summary>
    public class SimplePrinterBad : IMultiFunctionDeviceBad
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }

        public void Scan(string document)
        {
            throw new NotImplementedException("This printer cannot scan");
        }

        public void Fax(string document)
        {
            throw new NotImplementedException("This printer cannot fax");
        }

        public void Photocopy(string document)
        {
            throw new NotImplementedException("This printer cannot photocopy");
        }
    }
}
