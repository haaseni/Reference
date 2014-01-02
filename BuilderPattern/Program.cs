using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CarShop carshop = new CarShop();
            CarBuilder carbuilder;

            carbuilder = new ConvertibleBuilder();
            carshop.BuildCar(carbuilder);
            carbuilder.Car.DisplayCar();

            carbuilder = new CoupeBuilder();
            carshop.BuildCar(carbuilder);
            carbuilder.Car.DisplayCar();

            carbuilder = new SedanBuilder();
            carshop.BuildCar(carbuilder);
            carbuilder.Car.DisplayCar();

            carbuilder = new SUVBuilder();
            carshop.BuildCar(carbuilder);
            carbuilder.Car.DisplayCar();

            carbuilder = new TruckBuilder();
            carshop.BuildCar(carbuilder);
            carbuilder.Car.DisplayCar();

            Console.ReadKey();
        }
    }

    public class CarShop
    {
        public void BuildCar(CarBuilder builder)
        {
            builder.BuildChassis();
            builder.BuildDrivetrain();
            builder.BuildBody();
            builder.BuildElectrical();
            builder.BuildInterior();
        }
    }

    public abstract class CarBuilder
    {
        public Car Car { get; set; }

        public abstract void BuildChassis();
        public abstract void BuildDrivetrain();
        public abstract void BuildBody();
        public abstract void BuildElectrical();
        public abstract void BuildInterior();
    }

    public class ConvertibleBuilder : CarBuilder
    {
        public ConvertibleBuilder()
        {
            Car = new Car(CarType.Convertible);
        }

        public override void BuildChassis()
        {
            Car.Chassis = "Convertible Chassis";
        }

        public override void BuildDrivetrain()
        {
            Car.Drivetrain = "Convertible Drivetrain";
        }

        public override void BuildBody()
        {
            Car.Body = "Convertible Body";
        }

        public override void BuildElectrical()
        {
            Car.Electrical = "Convertible Electrical";
        }

        public override void BuildInterior()
        {
            Car.Interior = "Convertible Interior";
        }
    }
    public class CoupeBuilder : CarBuilder
    {
        public CoupeBuilder()
        {
            Car = new Car(CarType.Coupe);
        }

        public override void BuildChassis()
        {
            Car.Chassis = "Coupe Chassis";
        }

        public override void BuildDrivetrain()
        {
            Car.Drivetrain = "Coupe Drivetrain";
        }

        public override void BuildBody()
        {
            Car.Body = "Coupe Body";
        }

        public override void BuildElectrical()
        {
            Car.Electrical = "Coupe Electrical";
        }

        public override void BuildInterior()
        {
            Car.Interior = "Coupe Interior";
        }
    }
    public class SedanBuilder : CarBuilder
    {
        public SedanBuilder()
        {
            Car = new Car(CarType.Sedan);
        }

        public override void BuildChassis()
        {
            Car.Chassis = "Sedan Chassis";
        }

        public override void BuildDrivetrain()
        {
            Car.Drivetrain = "Sedan Drivetrain";
        }

        public override void BuildBody()
        {
            Car.Body = "Sedan Body";
        }

        public override void BuildElectrical()
        {
            Car.Electrical = "Sedan Electrical";
        }

        public override void BuildInterior()
        {
            Car.Interior = "Sedan Interior";
        }
    }
    public class SUVBuilder : CarBuilder
    {
        public SUVBuilder()
        {
            Car = new Car(CarType.SUV);
        }

        public override void BuildChassis()
        {
            Car.Chassis = "SUV Chassis";
        }

        public override void BuildDrivetrain()
        {
            Car.Drivetrain = "SUV Drivetrain";
        }

        public override void BuildBody()
        {
            Car.Body = "SUV Body";
        }

        public override void BuildElectrical()
        {
            Car.Electrical = "SUV Electrical";
        }

        public override void BuildInterior()
        {
            Car.Interior = "SUV Interior";
        }
    }
    public class TruckBuilder : CarBuilder
    {
        public TruckBuilder()
        {
            Car = new Car(CarType.Truck);
        }

        public override void BuildChassis()
        {
            Car.Chassis = "Truck Chassis";
        }

        public override void BuildDrivetrain()
        {
            Car.Drivetrain = "Truck Drivetrain";
        }

        public override void BuildBody()
        {
            Car.Body = "Truck Body";
        }

        public override void BuildElectrical()
        {
            Car.Electrical = "Truck Electrical";
        }

        public override void BuildInterior()
        {
            Car.Interior = "Truck Interior";
        }
    }

    public class Car
    {
        private CarType _cartype;

        public string Chassis { get; set; }
        public string Drivetrain { get; set; }
        public string Body { get; set; }
        public string Electrical { get; set; }
        public string Interior { get; set; }

        public Car(CarType cartype)
        {
            _cartype = cartype;
        }

        public void DisplayCar()
        {
            string message;

            message = string.Format("Type: {0}", _cartype);
            Console.WriteLine(message);
            message = string.Format("Chassis: {0}", Chassis);
            Console.WriteLine(message);
            message = string.Format("Drivetrain: {0}", Drivetrain);
            Console.WriteLine(message);
            message = string.Format("Body: {0}", Body);
            Console.WriteLine(message);
            message = string.Format("Electrical: {0}", Electrical);
            Console.WriteLine(message);
            message = string.Format("Interior: {0}", Interior);
            Console.WriteLine(message);

            Console.WriteLine();
        }
    }

    public enum CarType
    {        
        Convertible,
        Coupe,
        Sedan,
        SUV,
        Truck
    }
}
