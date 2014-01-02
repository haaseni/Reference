using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= Convert.ToInt32(Enum.GetValues(typeof(Cars)).Cast<Cars>().Max()); i++)
            {
                Cars cartype;
                Enum.TryParse(i.ToString(), out cartype);
                var car = CarFactory.Create(cartype);
                Console.WriteLine("id = {0}, car = {1}", i, car.Name);                
            }

            Console.ReadKey();
        }
    }

    public abstract class Car
    {
        public abstract string Name { get; }
    }

    public class BMW : Car
    {
        public override string Name
        {
            get { return "BMW"; }            
        }
    }

    public class Ferrari : Car
    {
        public override string Name
        {
            get { return "Ferrari"; }
        }
    }

    public class Toyota : Car
    {
        public override string Name
        {
            get { return "Toyota"; }
        }
    }

    public class Chevrolet : Car
    {
        public override string Name
        {
            get { return "Chevrolet"; }
        }
    }


    public static class CarFactory
    {
        public static Car Create(Cars car)
        {
            switch (car)
            {
                case Cars.BMW:
                    return new BMW();
                case Cars.Ferrari:
                    return new Ferrari();
                case Cars.Toyota:
                    return new Toyota();
                case Cars.Chevrolet:
                    return new Chevrolet();
            }

            return null;
        }
    }

    public enum Cars
    {
        BMW,
        Ferrari,
        Toyota,
        Chevrolet
    }
}
