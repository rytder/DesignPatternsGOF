using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        public static void Main(string[] args)
        {
            Proxy proxy = new Proxy("SomeLegitPassword");
            proxy.DoHeavyLifting();
        }
    }

    interface ISubject
    {
        void DoHeavyLifting();
    }

    class Proxy : ISubject
    {

        RealSubject realThing;
        string password;

        public Proxy(string password)
        {
            this.password = password;
        }

        public void DoHeavyLifting()
        {
            if (Auth(password))
            {
                realThing = new RealSubject();
                realThing.DoHeavyLifting();
            }
            else
            {
                Console.WriteLine("Did not authenticate - controlling when a costly object needs to be instantiated and initialized");
            }
        }

        public bool Auth(string password)
        {
            if(password == "SomeLegitPassword")
            {
                return true;       
            }
            return false;
        }

    }

    class RealSubject : ISubject
    {
        public void DoHeavyLifting()
        {
            Console.WriteLine("I am doing some real heavy lifting");
        }
    }


}
