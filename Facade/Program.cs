using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade bankFacade = new Facade(123456, 1234);

            bankFacade.DepositCash(1000);

            bankFacade.WithdrawMoney(500);
        }

        public class WelcomeToBank
        {
            public WelcomeToBank()
            {
                Console.WriteLine("Welcome to RYTIS BANK\nHope you will have a pleasant experience");
            }
        }

        public class AccountNumberCheker
        {
            private int accountNumber = 123456;

            public int GetAccountNumber() { return accountNumber; }

            public bool IsAccountNumberActiveAndCorrect(int accountNumbToCheck)
            {
                if (accountNumber == GetAccountNumber())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class SecurityCodeCheker
        {
            private int securityCode = 1234;

            public int GetSucurityCode() { return securityCode; }

            public bool CheckSecurityCode(int securityCode)
            {
                if (securityCode == GetSucurityCode())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class FundsLogic
        {
            private double funds = 1000.0;

            public double GetCurrentFunds() { return funds; }

            public void DecreaseMoneyInAcc(double amount)
            {
                funds -= amount;
            }

            public void IncreaseMoneyInAcc(double amount)
            {
                funds += amount;
            }

            public bool HasEnoughMoney(double amount)
            {
                if (GetCurrentFunds() >= amount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void WithdrawMoney(double amount)
            {
                if (HasEnoughMoney(amount))
                {
                    DecreaseMoneyInAcc(amount);
                    Console.WriteLine("Withdrawal complete!" + " Funds Left: " + GetCurrentFunds());
                }
                else
                {
                    Console.WriteLine("Withdrawal failed!");
                }
            }

            public void MakeDeposit(double amount)
            {
                IncreaseMoneyInAcc(amount);
                Console.WriteLine("Succesful deposit! Current account balance: " + GetCurrentFunds());
            }

        }

        public class Facade
        {
            private int accountNumber;
            private int securityCode;

            WelcomeToBank welcomeToBank;
            AccountNumberCheker accountNumberCheker;
            SecurityCodeCheker securityCodeCheker;
            FundsLogic fundsLogic;

            public int GetAccountNumber() { return accountNumber; }
            public int GetSecurityCode() { return securityCode; }

            public Facade(int accountNumber, int securityCode)
            {
                this.accountNumber = accountNumber;
                this.securityCode = securityCode;

                welcomeToBank = new WelcomeToBank();
                accountNumberCheker = new AccountNumberCheker();
                securityCodeCheker = new SecurityCodeCheker();
                fundsLogic = new FundsLogic();
            }

            public void WithdrawMoney(double amount)
            {
                if (accountNumberCheker.IsAccountNumberActiveAndCorrect(GetAccountNumber())
                    && securityCodeCheker.CheckSecurityCode(GetSecurityCode())
                        && fundsLogic.HasEnoughMoney(amount))
                {
                    fundsLogic.WithdrawMoney(amount);
                    Console.WriteLine("Succesfully withdraw!");
                }
                else
                {
                    Console.WriteLine("Withdraw failed!");
                }
            }

            public void DepositCash(double amount)
            {
                if (accountNumberCheker.IsAccountNumberActiveAndCorrect(GetAccountNumber())
                    && securityCodeCheker.CheckSecurityCode(GetSecurityCode()))
                {
                    fundsLogic.IncreaseMoneyInAcc(amount);
                    Console.WriteLine("Succesfully increased!");
                }
                else
                {
                    Console.WriteLine("Deposit failed");
                }
            }


        }
    }
}
