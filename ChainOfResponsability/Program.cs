using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    class Program
    {
        private static Approver GetChainOfApprovers()
        {
            Approver director = new Director(100000);
            Approver manager = new Manager(10000);
            Approver clerk = new Clerk(1000);

            manager.SetNextApprover(director);
            clerk.SetNextApprover(manager);

            return clerk;
        }

        public static void Main(string[] args)
        {
            Approver chainOfApprovers = GetChainOfApprovers();

            Console.WriteLine("PHONE LOAN");
            chainOfApprovers.ApproveLoan(123);

            Console.WriteLine("\nBIKE LOAN");
            chainOfApprovers.ApproveLoan(1234);

            Console.WriteLine("\nHOUSE LOAN");
            chainOfApprovers.ApproveLoan(12345);

        }
    }

    abstract class Approver
    {
        private int maxApproveAmount;
        private Approver nextApprover;

        public Approver(int ammount)
        {
            this.maxApproveAmount = ammount;
        }

        public void SetNextApprover(Approver a)
        {
            this.nextApprover = a;
        }

        public void ApproveLoan(int amount)
        {
            if(amount <= maxApproveAmount)
            {
                Notify(true);
            }
            else
            {
                Notify(false);
                if (nextApprover != null)
                {
                    nextApprover.ApproveLoan(amount);
                }
            }
        }

        public abstract void Notify(bool approved);
    }

    class Clerk : Approver
    {
        public Clerk(int ammount) : base(ammount)
        {

        }

        public override void Notify(bool approved)
        {
            if (approved)
            {
                Console.WriteLine("Loan approved by CLERK");
            }
            else
            {
                Console.WriteLine("CLERK - I can not grant your wish, ask my boss");
            }
        }
    }

    class Manager : Approver
    {
        public Manager(int ammount) : base(ammount)
        {

        }

        public override void Notify(bool approved)
        {
            if (approved)
            {
                Console.WriteLine("Loan approved by MANAGER");

            }
            else
            {
                Console.WriteLine("MANAGER - I can not grant your wish, ask my boss");
            }
        }
    }

    class Director : Approver
    {
        public Director(int ammount) : base(ammount)
        {
                
        }

        public override void Notify(bool approved)
        {
            if (approved)
            {
                Console.WriteLine("Loan approved by DIRECTOR");
            }
            else
            {
                Console.WriteLine("DIRECTOR - sorry, we don't provide such a big loans");
            }
        }
    }
}
