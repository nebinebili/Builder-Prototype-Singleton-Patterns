using System;

namespace Builder
{

    class Car
    {
        public string CarType { get; set; }
        public int SeatsCount { get; set; }
        public double Engine { get; set; }
        public bool HasTripComputer { get; set; }
        public string GPS { get; set; }

        public override string ToString()
        {
            if (!HasTripComputer) GPS = "Not have";
            if (CarType == null) CarType = "None";
            return @$"
                      Car Type->{CarType}
                      Seats Count->{SeatsCount}
                      Engine->{Engine}
                      Has Trip Computer->{HasTripComputer}
                      GPS->{GPS}
                       ";

        }
    }

    interface IBuilder
    {
        public Car Car { get; set; }

        IBuilder Reset();
        IBuilder SetSeats(int seatsCount);
        IBuilder SetEngine(double engine);
        IBuilder SetTripComputer(bool hasTripComputer);
        IBuilder SetGPS(string hasGPS);
        Car GetResult();
    }



    class AutomaticCarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car();

        public Car GetResult() => Car;
        

        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGPS(string gPS)
        {
            Car.GPS = gPS;
            return this;
        }

        public IBuilder SetSeats(int seatsCount)
        {
            Car.SeatsCount = seatsCount;
            return this;
        }

        public IBuilder SetTripComputer(bool hasTripComputer)
        {
            Car.HasTripComputer = hasTripComputer;
            return this;
        }
    }

    class ManualCarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car();

        public Car GetResult() => Car;


        public IBuilder Reset()
        {
            Car = new Car();
            return this;
        }

        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGPS(string gPS)
        {
            Car.GPS = gPS;
            return this;
        }

        public IBuilder SetSeats(int seatsCount)
        {
            Car.SeatsCount = seatsCount;
            return this;
        }

        public IBuilder SetTripComputer(bool hasTripComputer)
        {
            Car.HasTripComputer = hasTripComputer;
            return this;
        }
    }

    class Master
    {
        private IBuilder _builder;

        public Master(IBuilder builder)
        {
            _builder = builder;
        }

        public void ChangeBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public Car Make(string type)
        {
            if (type == "Sport")
            {
                _builder.Car.CarType = "Sport";
                return _builder
                    .SetSeats(2)
                    .SetTripComputer(true)
                    .SetEngine(6.6)
                    .SetGPS("GPS Wifi 9 Android")
                    .GetResult();
            }
            else if (type == "Classic")
            {
                _builder.Car.CarType = "Classic";
                return _builder
                   .SetEngine(5)
                   .SetTripComputer(false)
                   .SetEngine(3.3)
                   .SetGPS("")
                   .GetResult();
            }
            throw new Exception("Wrong Type");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new AutomaticCarBuilder();
            Car carautomatic = builder.SetSeats(5).SetEngine(4.4).SetTripComputer(true).SetGPS(" GPS Wifi 9 Android ").GetResult();
            builder.Reset();
            Car carmanual = builder.SetSeats(5).SetEngine(2.2).SetTripComputer(false).SetGPS("").GetResult();

            Console.WriteLine(carmanual);
            Console.WriteLine(carautomatic);

            
            builder = new AutomaticCarBuilder();
            Master master = new Master(builder);

            Car car = master.Make("Sport");
            Console.WriteLine(car);
        }
    }
}
