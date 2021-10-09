using System;

namespace Prototype
{
    //class Computer:ICloneable
    //{
    //    public string Name { get; set; }
    //    public double Price { get; set; }

    //    public Computer()
    //    {

    //    }
    //    public Computer(Computer computer)
    //    {
    //        Name=computer.Name ;
    //        Price= computer.Price ;
    //    }

    //    public object Clone()=>new Computer(this);

    //    public override string ToString()
    //    {
    //        return $"Name->{Name}  Price->{Price}";
    //    }
    //}



    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Computer computer = new Computer { Name = "HP", Price = 1800 };
    //        Computer computerClone = computer.Clone() as Computer;
    //        Console.WriteLine(computer);
    //        computerClone.Price = 1500;
    //        Console.WriteLine(computerClone);
    //    }
    //}

    interface IPrototype
    {
        IPrototype Clone();
    }

    class Computer:IPrototype
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Computer()
        {

        }
        public Computer(Computer computer)
        {
            Name = computer.Name;
            Price = computer.Price;
        }

        public IPrototype Clone() => new Computer(this);

        public override string ToString()
        {
            return $"Name->{Name}  Price->{Price}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer { Name = "HP", Price = 1800 };
            Computer computerClone = computer.Clone() as Computer;
            Console.WriteLine(computer);
            computerClone.Price = 1500;
            Console.WriteLine(computerClone);
        }
    }
}
