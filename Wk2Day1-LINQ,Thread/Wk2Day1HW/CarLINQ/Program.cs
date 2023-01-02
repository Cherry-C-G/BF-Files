namespace CarLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a.Find the index of the first car whose price is smaller than 10000
            var c = new Car[]
            {
        new Car{ Color="Blue", Price=28000},
        new Car{ Color="Red", Price=54000},
        new Car{ Color="Pink", Price=9999},
        new Car{ Color="Black", Price=46722},
        new Car{ Color="White", Price=35264}
            };
            int index = c.Select((car, i) => new { Car = car, Index = i })
                         .First(ci => ci.Car.Price < 10000)
                         .Index;
            Console.WriteLine($"The index of the first car whose price is smaller than 10000 is {index}.");
            Console.WriteLine();

            // b.Find the colors for the top 3 highest car prices
            var top3 = c.OrderByDescending(car => car.Price)
                        .Take(3)
                        .Select(car => car.Color);
            Console.WriteLine("The colors for the top 3 highest car prices are:");
            Console.WriteLine(string.Join(", ", top3));
        }
    }
}