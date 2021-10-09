using System;

namespace Singleton
{
    public sealed class Singleton
    {
        private static volatile Singleton _instance = null;
        private static object _syncRoot = new Object();
        public string CarName { get; set; }
        public string CarModel { get; set; }

        public override string ToString()
        {
            return @$"
Car Name->{CarName}
Car Model->{CarModel}";
        }


        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new Singleton { CarName = "KIA", CarModel = "Sportage" };
                    }
                }
                return _instance;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton car1 = Singleton.Instance;
            Singleton car2 = Singleton.Instance;

            Console.WriteLine(car2);



        }
    }
}
