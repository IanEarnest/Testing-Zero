using System;
using System.Collections.Generic;
using System.Text;

namespace T1ConsoleApp
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAcc4Testing
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAcc4Testing() { }

        public BankAcc4Testing(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        public const string Debit_AccTooLow_M = "Debit amount exceeds balance";
        public const string Debit_IncorrectAmount_M = "Debit amount is less than zero";
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, Debit_AccTooLow_M);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, Debit_IncorrectAmount_M);
            }

            m_balance += amount; // intentionally incorrect code
        }
        
        public void Debit_Fixed(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
        
        public static void BankMain()
        {
            BankAcc4Testing ba = new BankAcc4Testing("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}
