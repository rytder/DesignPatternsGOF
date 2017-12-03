using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        public static void Main(string[] args)
        {
            // create Context object and suplied current state or initial state (state A).
            Context context = new Context();

            context.Request();
            context.Request();
            context.Request();
        }

        public interface IStateBase
        {
            void Change(Context context);
        }

        public class StateA : IStateBase
        {
            public void Change(Context context)
            {
                //Change state of context from A to B.
                context.State = new StateB();
                Console.WriteLine("Change state from A to B");
            }
        }

        public class StateB : IStateBase
        {
            public void Change(Context context)
            {
                //Change state of context from B to C.
                context.State = new StateC();
                Console.WriteLine("Change state from B to C");
            }
        }

        public class StateC : IStateBase
        {
            public void Change(Context context)
            {
                //Change state of context from C to A.
                context.State = new StateA();
                Console.WriteLine("Change state from C to A");
            }
        }

        public class Context
        {
            public IStateBase State { get; set; }

            public Context()
            {
                //Begin from a state, could receive parameter if it would be app with memory
                State = new StateA();
                Console.WriteLine("Create object of context class with initial State");
            }

            public void Request()
            {
                State.Change(this);
            }
        }
    }
}
