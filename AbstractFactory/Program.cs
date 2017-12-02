using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitFactory uf;
            uf = UnitFactory.CreateFactory("P");
            Unit myUnit = uf.CreateUnit("1");
            Console.WriteLine(myUnit.ToString());

        }
    }

    abstract class Unit
    {
        public string Name { get; set; }

        public int Dmg { get; set; }

        public Unit(string name, int dmg)
        {
            Name = name;
            Dmg = dmg;
        }

    }

    class Plane : Unit
    {
        public Plane(string name, int dmg) : base(name, dmg)
        {

        }
    }

    class Ship : Unit
    {
        public Ship(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class Jet : Plane
    {
        public Jet(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class Bomber : Plane
    {
        public Bomber(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class Submarine : Ship
    {
        public Submarine(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class AirCarrier : Ship
    {
        public AirCarrier(string name, int dmg) : base(name, dmg)
        {
        }
    }

    class UnitFactory
    {
        static public UnitFactory CreateFactory(string factoryName)
        {
            if (factoryName == "P")
            {
                return new PlaneFactory();
            }
            else if (factoryName == "S")
            {
                return new ShipFactory();
            }
            return null;
        }

        public virtual Unit CreateUnit(String unitType)
        {
            return null;
        }
    }

    class PlaneFactory : UnitFactory
    {
        public override Unit CreateUnit(string unitType)
        {
            if (unitType == "1")
            {
                return new Jet("Naikintuvas", 90);
            }
            else if (unitType == "2")
            {
                return new Bomber("Bomberis", 100);
            }
            return null;
        }
    }

    class ShipFactory : UnitFactory
    {
        public override Unit CreateUnit(string unitType)
        {
            if (unitType == "1")
            {
                return new AirCarrier("Naikituvu laivas", 500);
            }
            if (unitType == "2")
            {
                return new Submarine("Povandeninis Laivas", 50);
            }
            return null;
        }
    }
}
