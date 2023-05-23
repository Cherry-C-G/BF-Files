using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;

namespace FactoryDesignPattern_AbstractFactory
{
    /// <summary>
    /// Abstract Factory Idea: Suppose you have factories to produce computers: 
    /// CPU Factory to produce different model of CPUs,
    /// Monitor Factory to produce different size of monitors ...
    /// If a client needs to by a computer, we have factories that can produce different components
    /// but these components need to be managed and assembled by another Factory.
    /// </summary>

    //Example Abstract Factory: can draw shapes and fill colors
    abstract class AbstractFactory
    {
        public abstract IColor GetColor(string colorType);
        public abstract IShape GetShape(string shapeType);
    }

    //Color Factory
    #region 1. Create interface
    public interface IColor
    {
        void Fill();
    }
    #endregion

    #region 2. create classes that can be created by Color Factory 
    class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filling Red.");
        }
    }
    class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filling Green.");
        }
    }
    class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Filling Blue.");
        }
    }

    #endregion

    #region 3. Inplement simple factory in abstract factory
    class ColorFactory : AbstractFactory
    {
        public override IColor GetColor(string colorType)
        {
            switch (colorType)
            {
                case "red":
                    return new Red();
                case "green":
                    return new Green();
                case "blue":
                    return new Blue();
                default:
                    return null;
            }
        }

        public override IShape GetShape(string shapeType)
        {
            return null;
        }
    }
    #endregion

    //Shape Factory
    #region 1. Create interface
    public interface IShape
    {
        void Draw();
    }
    #endregion

    #region 2. create classes that can be created by Color Factory 
    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circles.");
        }
    }
    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Rectangles.");
        }
    }
    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Squares.");
        }
    }

    #endregion

    #region 3. Inplement simple factory in abstract factory
    class ShapeFactory : AbstractFactory
    {
        public override IColor GetColor(string colorType)
        {
            return null;
        }

        public override IShape GetShape(string shapeType)
        {
            switch (shapeType)
            {
                case "circle":
                    return new Circle();
                case "rectangle":
                    return new Rectangle();
                case "square":
                    return new Square();
                default:
                    return null;
            }
        }
    }
    #endregion

    // Use a FactoryCreator to help us generate the Factory
    class FactoryCreator
    {
        public static AbstractFactory Create(string factoryType) 
        {
          switch(factoryType)
            {
                case "shape":
                    return new ShapeFactory();
                case "color":
                    return new ColorFactory();
                default:
                    return null;
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory abstractFactory = FactoryCreator.Create("color");
            IColor colorBlue = abstractFactory.GetColor("blue");
            colorBlue.Fill();
            IColor colorRed = abstractFactory.GetColor("red");
            colorRed.Fill();
            IColor colorGreen = abstractFactory.GetColor("green");
            colorGreen.Fill();

            AbstractFactory abFactory = FactoryCreator.Create("shape");
            IShape shapeCircle = abFactory.GetShape("circle");
            shapeCircle.Draw();
            IShape shapeRectangle = abFactory.GetShape("rectangle");
            shapeRectangle.Draw();
            IShape shapeSquare = abFactory.GetShape("square");
            shapeSquare.Draw();
        }
    }
}