using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            EnemyShipFactory factory = new EnemyShipFactory();

            Enemy terran = factory.MakeEnemyShip("TERRAN");
            Enemy ufo = factory.MakeEnemyShip("UFO");

            Console.WriteLine(terran.Name);
            Console.WriteLine(terran.Dmg);

            Console.WriteLine("-/-/-/-/-/-");

            Console.WriteLine(ufo.Name);
            Console.WriteLine(ufo.Dmg);

        }
    }

    abstract class Enemy
    {
        public string Name { get; set; }
        public int Dmg { get; set; }

        public Enemy(string name, int dmg)
        {
            Name = name;
            Dmg = dmg;
        }
    }

    class UFOShip : Enemy
    {
        public UFOShip(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class TerranShip : Enemy
    {
        public TerranShip(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class EnemyShipFactory
    {
        public Enemy MakeEnemyShip(string shipType)
        {
            if (shipType != "")
            {
                if (shipType == "UFO")
                {
                    return new UFOShip("UFO", 10);
                }
                else if (shipType == "TERRAN")
                {
                    return new TerranShip("TERRAN", 20);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
