namespace SOLIDPrinciples.LiskovSubstitution.Good
{
    /// <summary>
    /// Base class for all birds with common behavior
    /// </summary>
    public abstract class Bird
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }

        public abstract void Move();
    }

    /// <summary>
    /// Abstract class for birds that can fly.
    /// Only flying birds inherit from this.
    /// </summary>
    public abstract class FlyingBird : Bird
    {
        public void Fly()
        {
            Console.WriteLine($"{Name} is flying");
        }

        public override void Move()
        {
            Fly();
        }
    }

    /// <summary>
    /// Sparrow can fly - correctly inherits from FlyingBird
    /// </summary>
    public class Sparrow : FlyingBird
    {
        public Sparrow()
        {
            Name = "Sparrow";
        }
    }

    /// <summary>
    /// Eagle can fly - correctly inherits from FlyingBird
    /// </summary>
    public class Eagle : FlyingBird
    {
        public Eagle()
        {
            Name = "Eagle";
        }
    }

    /// <summary>
    /// Penguin cannot fly - inherits directly from Bird, not FlyingBird.
    /// This doesn't violate LSP because Penguin doesn't promise to fly.
    /// </summary>
    public class Penguin : Bird
    {
        public Penguin()
        {
            Name = "Penguin";
        }

        public void Swim()
        {
            Console.WriteLine($"{Name} is swimming");
        }

        public override void Move()
        {
            Swim(); // Penguins move by swimming
        }
    }

    /// <summary>
    /// GOOD: Proper shape hierarchy that follows LSP
    /// </summary>
    public interface IShape
    {
        int GetArea();
    }

    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    public class Square : IShape
    {
        public int SideLength { get; set; }

        public Square(int sideLength)
        {
            SideLength = sideLength;
        }

        public int GetArea()
        {
            return SideLength * SideLength;
        }
    }

    /// <summary>
    /// Example demonstrating correct LSP implementation
    /// </summary>
    public class LspCorrectExample
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=== Correct Bird Hierarchy ===");
            
            // All birds can eat and sleep
            List<Bird> allBirds = new List<Bird>
            {
                new Sparrow(),
                new Eagle(),
                new Penguin()
            };

            foreach (var bird in allBirds)
            {
                bird.Eat();
                bird.Move(); // Each bird moves in its own way
            }

            // Only flying birds can fly
            Console.WriteLine("\n=== Flying Birds ===");
            List<FlyingBird> flyingBirds = new List<FlyingBird>
            {
                new Sparrow(),
                new Eagle()
                // Penguin is NOT in this list - no LSP violation!
            };

            foreach (var bird in flyingBirds)
            {
                bird.Fly(); // All birds in this list can fly
            }

            // Shapes example
            Console.WriteLine("\n=== Shapes ===");
            List<IShape> shapes = new List<IShape>
            {
                new Rectangle(5, 10),
                new Square(5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Area: {shape.GetArea()}");
            }
            
            // Each shape calculates area correctly without surprises
        }
    }
}
