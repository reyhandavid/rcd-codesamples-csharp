namespace SOLIDPrinciples.LiskovSubstitution.Bad
{
    /// <summary>
    /// BAD EXAMPLE: Violates LSP because not all birds can fly
    /// </summary>
    public class BirdBad
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying in the sky");
        }
    }

    public class SparrowBad : BirdBad
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow flying");
        }
    }

    /// <summary>
    /// PROBLEM: Penguin is a bird but can't fly!
    /// This violates LSP because Penguin can't be substituted for Bird.
    /// </summary>
    public class PenguinBad : BirdBad
    {
        public override void Fly()
        {
            // Penguins can't fly!
            throw new NotSupportedException("Penguins cannot fly");
        }
    }

    /// <summary>
    /// Another LSP violation: Rectangle/Square problem
    /// </summary>
    public class RectangleBad
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    /// <summary>
    /// PROBLEM: Square violates LSP because it changes the behavior.
    /// Setting Width should only change Width, but in Square it changes both.
    /// </summary>
    public class SquareBad : RectangleBad
    {
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value; // Violates expected behavior!
            }
        }

        public override int Height
        {
            get => base.Height;
            set
            {
                base.Width = value; // Violates expected behavior!
                base.Height = value;
            }
        }
    }

    public class LspViolationExample
    {
        public static void DemonstrateProblems()
        {
            // Problem 1: Bird hierarchy
            Console.WriteLine("=== Bird Hierarchy Problem ===");
            List<BirdBad> birds = new List<BirdBad>
            {
                new SparrowBad(),
                new PenguinBad() // Adding penguin causes problems
            };

            foreach (var bird in birds)
            {
                try
                {
                    bird.Fly(); // Will throw exception for penguin!
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // Problem 2: Rectangle/Square
            Console.WriteLine("\n=== Rectangle/Square Problem ===");
            RectangleBad rect = new SquareBad();
            rect.Width = 5;
            rect.Height = 10;
            
            // Expected: 50 (5 * 10)
            // Actual: 100 (10 * 10) because Square changed both dimensions
            Console.WriteLine($"Expected area: 50, Actual area: {rect.GetArea()}");
            // This breaks the expected behavior of Rectangle!
        }
    }
}
