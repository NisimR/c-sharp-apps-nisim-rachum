using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_nisim_rachum.BankApp
{
    public class Account
    {
        private Owner o;
        private double balance = 0;
        private int overdraft = 0;
        private const int MAX_OVERDRAFT = -90000;

        public Account(Owner owner, double balance, int overdraft)
        {
            this.o = owner;
            this.balance = balance;
            this.overdraft = overdraft;

        }

        public Owner GetOwner()
        {
            return o;
        }

        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        public double GetBalance()
        {
            return this.balance;
        }

        public void SetOverdraft(int overdraft)
        {
            if (-overdraft >= MAX_OVERDRAFT)
            {
                this.overdraft = overdraft;
            }
            else
            {
                Console.WriteLine("Too mach value ");
            }
        }

        public int GetOverdraft()
        {
            return this.overdraft;
        }

        public void Deposit(double deposit)
        {
            this.balance += deposit;
            //Console.WriteLine("The balance after deposit is:" + this.balance);
        }

        public void Withdraw(double amount)
        {
            if (amount <= Math.Abs(balance)+ Math.Abs(overdraft))
            {
                this.balance -= amount;
                //Console.WriteLine("The balance after withdraw is:" + balance);
            }
        }

    }
}
