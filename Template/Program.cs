using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.DailyRoutine();

            Programmer programmer = new Programmer();
            programmer.DailyRoutine();
        }
    }

    public abstract class Worker
    {
        public void DailyRoutine()
        {
            Sleep();
            Eat();
            Work();
        }

        void Sleep()
        {
            Console.WriteLine("I am sleeping");
        }

        void Eat()
        {
            Console.WriteLine("I am eating");
        }

        abstract public void Work();
    }

    class Manager : Worker
    {
        public override void Work()
        {
            Console.WriteLine("I am manager, managing others");
        }
    }

    class Programmer : Worker
    {
        public override void Work()
        {
            Console.WriteLine("I am programmer, I do stuff like programming");
        }
    }
}
