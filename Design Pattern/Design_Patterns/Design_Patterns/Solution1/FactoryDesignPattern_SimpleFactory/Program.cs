namespace FactoryDesignPattern_SimpleFactory
{
    /// <summary>
    /// Factory:   Outsourcing the creation of objects to another class/method
    /// </summary>

    #region Step1: Define interfaces
    public interface IShape
    {
        void Draw();
    }
    #endregion

    #region Step2: Create implementing class
    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw() in Rectangle class");
        }
    }

    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw() in Square class");
        }
    }

    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw() in Circle class");
        }
    }

    #endregion

    #region Step3: Create a factory
    //The factory can create corresponding objects based on given information
    class ShapeFactory
    {
        //We can return any Shape that implements the IShape interface
        public IShape GetShape(string shapeType)
        {
            // validate input operation
            switch (shapeType)
            {
                case "rectangle":
                    return new Rectangle();
                case "square":
                    return new Square();
                case "circle":
                    return new Circle();
                default:
                    return null;
            }
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            //use factory to create objects for us.
            ShapeFactory factory = new ShapeFactory();
            IShape circle = factory.GetShape("circle");  // Circle circle = new Circle();
            circle.Draw();
            IShape square = factory.GetShape("square"); // Square square = new Square();
            square.Draw();
            IShape rectangle = factory.GetShape("rectangle"); // Rectangle rectangle = new Rectangle();
            rectangle.Draw();
        }
    }
}