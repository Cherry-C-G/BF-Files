namespace SLOD_LiskovSubstitutionPrinciple
{
    /// <summary>
    /// A sub-class should be able to substitute its parent class without any problem.
    /// </summary>
    public class Rectangle
    {
        public  int Width { get; set; }
        public  int Height { get; set; }
        public Rectangle(){}

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public new int Width { set { base.Width = base.Height = value; } }
        public new int Height { set { base.Width = base.Height = value; } }
    }
    internal class Program
    {
        public static  int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2, 3);
            Console.WriteLine($"{rectangle} has area {Area(rectangle)}");
           
            //Square square = new Square();
            //Even we store this Square in Rectengle it should behave as a Square
            //However, in this case, the LSP has been violated.
            //Can you make it work properly?
            Rectangle square = new Square(); 
            square.Width = 5;
            Console.WriteLine( $"{square} has area { Area(square)}");

        }
    }
}