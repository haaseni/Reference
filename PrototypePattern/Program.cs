using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var showroom = new Showroom();

            showroom.AddCar("Ferrari", new Ferrari("450GT-P"));
            showroom.AddCar("Porsche", new Porsche("911-P"));

            string sourcename;
            string currentname;

            var clonedferrari = (Ferrari)showroom.GetCar("Ferrari");
            clonedferrari.Name = "450GT";
            sourcename = showroom.GetCar("Ferrari").Name;
            currentname = clonedferrari.Name;
            Console.WriteLine(string.Format("{0} | {1}", sourcename, currentname));

            var clonedporsche = (Porsche)showroom.GetCar("Porsche");
            clonedporsche.Name = "911";
            sourcename = showroom.GetCar("Porsche").Name;
            currentname = clonedporsche.Name;
            Console.WriteLine(string.Format("{0} | {1}", sourcename, currentname));

            Console.ReadKey();
        }
    }

    public class Showroom
    {
        private Dictionary<string, CarPrototype> _cars = new Dictionary<string, CarPrototype>();

        public void AddCar(string key, CarPrototype prototype)
        {
            _cars.Add(key, prototype);
        }

        public CarPrototype GetCar(string key)
        {
            var car = _cars[key];
            return car.Clone();
        }
    }

    public abstract class CarPrototype
    {
        public string Name { get; set; }

        public CarPrototype(string name)
        {
            Name = name;
        }

        public abstract CarPrototype Clone();
    }

    public class Ferrari : CarPrototype
    {
        public Ferrari(string name) 
            : base(name) 
        { }


        public override CarPrototype Clone()
        {
            return (CarPrototype)this.MemberwiseClone();
        }
    }

    public class Porsche : CarPrototype
    {
        public Porsche(string name)
            : base(name)
        { }

        public override CarPrototype Clone()
        {
            return (CarPrototype)this.MemberwiseClone();
        }
    }
}
