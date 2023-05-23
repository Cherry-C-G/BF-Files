//Practice 4: C#
//Develop a program to build car factory
//Instructions:
//Create a Car Model (Id, Name, Model, Make, Year, Speed, Weels, Miles)
//Create a Factory to build a car for given inputs
//Design methods like InitializeCar, SetSpeed, SetModel, SetMake, SetYear, SetWeels, SetMiles, GetCarInfo
//Inputs:
//Name, Model, Make, Speed, Weels, Miles
//Output:
//Hello you choose {Name} { Make}
//of
//{ Model}
//with
//{ }
//weels with speed of {Speed}
//and it runs {Miles}
//Note:
//Extend this program to support any kind vehicle. (Car, Bike, Motor-Cycle)
//Use Inheritance, Constructor, properties, Exception Handlin

using System;

public class Vehicle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Make { get; set; }
    public int Year { get; set; }
    public int Speed { get; set; }
    public int Wheels { get; set; }
    public int Miles { get; set; }

    public Vehicle(string name, string make, string model, int speed, int wheels, int miles)
    {
        Name = name;
        Make = make;
        Model = model;
        Speed = speed;
        Wheels = wheels;
        Miles = miles;
    }

    public void InitializeVehicle(int year)
    {
        Year = year;
    }

    public void SetSpeed(int speed)
    {
        Speed = speed;
    }

    public void SetModel(string model)
    {
        Model = model;
    }

    public void SetMake(string make)
    {
        Make = make;
    }

    public void SetYear(int year)
    {
        Year = year;
    }

    public void SetWheels(int wheels)
    {
        Wheels = wheels;
    }

    public void SetMiles(int miles)
    {
        Miles = miles;
    }

    public void GetVehicleInfo()
    {
        Console.WriteLine($"Hello, you have chosen a {Name} {Make} of {Model} model with {Wheels} wheels. It has a speed of {Speed} km/hr and it has run for {Miles} miles.");
    }
}

public class Car : Vehicle
{
    public Car(string name, string make, string model, int speed, int wheels, int miles) : base(name, make, model, speed, wheels, miles)
    {
    }
}

public class Bike : Vehicle
{
    public Bike(string name, string make, string model, int speed, int wheels, int miles) : base(name, make, model, speed, wheels, miles)
    {
    }
}

public class Motorcycle : Vehicle
{
    public Motorcycle(string name, string make, string model, int speed, int wheels, int miles) : base(name, make, model, speed, wheels, miles)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Car", "BMW", "X5", 200, 4, 1000);
        car.InitializeVehicle(2021);
        car.GetVehicleInfo();

        Bike bike = new Bike("Bike", "Harley Davidson", "Street 750", 120, 2, 500);
        bike.InitializeVehicle(2022);
        bike.GetVehicleInfo();

        Motorcycle motorcycle = new Motorcycle("Motorcycle", "Ducati", "Panigale V4", 300, 2, 100);
        motorcycle.InitializeVehicle(2023);
        motorcycle.GetVehicleInfo();

        Console.ReadKey();
    }
}
