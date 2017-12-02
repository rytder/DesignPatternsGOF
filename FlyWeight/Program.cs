using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class Program
    {
        public static void Main(string[] args)
        {
            GeometryFactory flyweight = new GeometryFactory();
            Console.WriteLine("********** OBJECT DETAILS **********");
            IGeometry geometry = flyweight.GetGeometry("Rectangle");
            geometry.GetShape();
            geometry.GetColor(15);

            Console.WriteLine("********** OBJECT DETAILS **********");
            geometry = flyweight.GetGeometry("Square");
            geometry.GetShape();
            geometry.GetColor(5);

            Console.WriteLine("********** OBJECT DETAILS **********");
            geometry = flyweight.GetGeometry("Rectangle");
            geometry.GetShape();
            geometry.GetColor(15);


            Console.WriteLine("\n********** DICTONARY DETAILS **********");
            Console.WriteLine("Objects Created: " + flyweight.GetGeometriesCount());
        }
    }

    public interface IGeometry
    {
        void GetShape();
        void GetColor(int size);
    }

    public class Rectangle : IGeometry
    {

        string Img { get; set; }

        //INTRINSIC STATE
        public void GetColor(int size)
        {
            if(size > 10)
            {
                Console.WriteLine("Geometry color is RED");
            }
            else
            {
                Console.WriteLine("Geometry color is BLACK");
            }
        }

        //EXTRINSIC STATE
        public void GetShape()
        {
            Console.WriteLine("This is a Rectangle");
        }
    }

    public class Square : IGeometry
    {
        //INTRINSIC STATE
        public void GetColor(int size)
        {
            if (size > 10)
            {
                Console.WriteLine("Geometry color is RED");
            }
            else
            {
                Console.WriteLine("Geometry color is BLACK");
            }
        }

        //EXTRINSIC STATE
        public void GetShape()
        {
            Console.WriteLine("This is a Square");
        }
    }

    public class GeometryFactory
    {
        Dictionary<string, IGeometry> geometries = new Dictionary<string, IGeometry>();

        public int GetGeometriesCount()
        {
            return geometries.Count;
        }

        public IGeometry GetGeometry(string name)
        {
            if (geometries.ContainsKey(name))
            {
                return geometries[name];
            }
            else
            {
                IGeometry geometry;
                switch (name)
                {
                    case ("Square"):
                        geometry = new Square();
                        geometries.Add("Square", geometry);
                        break;
                    case ("Rectangle"):
                        geometry = new Square();
                        geometries.Add("Rectangle", geometry);
                        break;
                    default:
                        throw new Exception("Can not create such geometry :)");
                }
                return geometry;
            }
        }
    }
}
