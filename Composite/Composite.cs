using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Composite
    {
        public static void Main(string[] args)
        {
            CompositeObject ceo = new CompositeObject("Rytis");

            CompositeObject director = new CompositeObject("John");
            CompositeObject director2 = new CompositeObject("Lenon");

            CompositeObject manager = new CompositeObject("Christina");
            CompositeObject manager2 = new CompositeObject("Bob");

            Leaf programmer = new Leaf("Richard");
            Leaf programmer2 = new Leaf("Kenny");

            manager.Add(programmer);
            manager2.Add(programmer2);

            director.Add(manager);
            director2.Add(manager2);

            ceo.Add(director);
            ceo.Add(director2);

            ceo.Display(1);
        }
    }

    abstract class Employee
    {
        protected List<Employee> employees;
        protected string Name { get; set; }

        public Employee(string name)
        {
            this.Name = name;
            employees = new List<Employee>();
        }

        public abstract void Add(Employee e);
        public abstract void Remove(Employee e);
        public abstract void Display(int indent);
    }

    class CompositeObject : Employee
    {
        public CompositeObject(string name) : base(name)
        {

        }

        public override void Add(Employee e)
        {
            employees.Add(e);
        }

        public override void Remove(Employee e)
        {
            employees.Remove(e);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + " " + Name);

            foreach (var employee in employees)
            {
                employee.Display(indent + 1);
            }
        }
    }

    class Leaf : Employee
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Employee e)
        {
            Console.WriteLine("LEAF object - can not add any child objects");
        }

        public override void Remove(Employee e)
        {
            Console.WriteLine("LEAF object - can not remove/add any child objects");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + " " + Name);
        }
    }
}
