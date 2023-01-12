namespace Fundamentals
{
    public interface Vehicle {
        public string move();
    }
    public class Class
    {
    }

    public class Car : Vehicle
    {
        public string move()
        {
            return "car";
        }
    }
    public class Plane : Vehicle
    {
        public string move()
        {
            return "plane";
        }
    }

    public class UserConfigModel {
        public const string UserConfig = "UserConfig";
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}
