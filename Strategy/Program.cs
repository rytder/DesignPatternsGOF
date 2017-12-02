using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal joe = new Dog();
            Animal kirsy = new Cat();

            Console.WriteLine(kirsy.Sound);
            ((Dog)joe).DigHole();

            Console.WriteLine(kirsy.TryToFly());
            Console.WriteLine(joe.TryToFly());
        }

    }

    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sound { get; set; }

        public IFlys flyingType;

        public Animal()
        {

        }

        public string TryToFly()
        {
            return flyingType.Fly();
        }

        public void SetFlyingAbility(IFlys newFlyType)
        {
            flyingType = newFlyType;
        }
    }

    class Dog : Animal
    {
        public void DigHole()
        {
            Console.WriteLine("Dug a hole");
        }

        public Dog()
        {
            Sound = "Bark Bark!";
            flyingType = new CantFly();
        }
    }

    class Cat : Animal
    {
        public Cat()
        {
            Sound = "Meow";
            flyingType = new ItFlys();
        }
    }

    interface IFlys
    {
        string Fly();
    }

    class ItFlys : IFlys
    {
        public string Fly()
        {
            return "I'm flying";
        }
    }

    class CantFly : IFlys
    {
        public string Fly()
        {
            return "Can't fly";
        }
    }
}
