using System;
using T1ConsoleApp; // bank account

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BankTests
    {

        /*- Testing - BankAcc4Testing
What does it do - create new account and change balance

Variables = m_customerName (CustomerName func - returns customerName)
            m_balance (Balance func - returns customerName)

Functions = BankAcc4Testing (customerName, balance) - create account
	        CustomerName, Balance   - returns variables (fields?)
            Debit (amount)          - reduce m_balance by ammount
            Debit_Fixed (amount)    - reduce m_balance by ammount
            Credit (amount)         - increase to m_balance by ammount
            BankMain                - main, creates account, credits, debits and prints

Tests = 17 (+4 tutorial = 21)
CustomerName    - name                // should pass
Balance         - return              // should pass
Balance         - positive numbers    // should pass
Balance         - positive high numbers // should pass
Balance         - negative numbers    // should fail
Debit           - amount < 0          // should fail
Debit           - amount == 0         // should fail
Debit           - amount > m_balance  // should fail
Debit           - amount < m_balance  // should pass (will fail due to code)
Debit_Fixed     - amount <= 0         // should fail
Debit_Fixed     - amount == 0         // should fail
Debit_Fixed     - amount > m_balance  // should fail
Debit_Fixed     - amount < m_balance  // should pass
Credit          - negative numbers    // should fail
Credit          - 0 number            // should fail
Credit          - positive numbers    // should pass
BankMain        - just run and check print // should pass
         */

        /*
Expected fails = 4 (+1 tutorial = 5)
Debit               - Bug #1 IGNORE(fixed in Debit_Fixed)
Credit_Zero         - Bug #2 Error, can Credit 0 in account
Debit_Zero          - Bug #3 Error, can Debit 0 in account
DebitFixed_Zero     - Bug #4 Error, can Debit 0 in account
     */
        [TestMethod]
        public void CustomerName() // CustomerName    - name                // should pass
        {
            string name = "Mr. Steven Smith";
            string expected = name;
            string actual = "";
            BankAcc4Testing account = new BankAcc4Testing(name, 0);

            actual = account.CustomerName; // expected = Mr. Steven Smith
            Assert.AreEqual(expected, actual, true, "Account named INCORRECTLY");
        }
        [TestMethod]
        public void Balance() // Balance   - return        // should pass
        {
            double amount = 100.01;
            double expected = amount;
            double actual = 0.0;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", amount);

            actual = account.Balance; // expected = 100.01
            Assert.AreEqual(expected, actual, 0.001, "Account balance INCORRECT");
        }
        [TestMethod]
        public void Balance_Positive() // Balance   - positive numbers    // should pass
        {
            double amount = 100.01;
            double expected = amount;
            double actual = 0.0;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", amount);

            actual = account.Balance; // expected = 100.01
            Assert.AreEqual(expected, actual, 0.001, "Account balance INCORRECT");



            double amount2 = 100000000.01;
            double expected2 = amount2;
            double actual2 = 0.0;
            BankAcc4Testing account2 = new BankAcc4Testing("Mr. Steven Smith", amount2);

            actual2 = account2.Balance; // expected = 100000000.01
            Assert.AreEqual(expected2, actual2, 0.001, "Account balance INCORRECT");
        }
        [TestMethod]
        public void Balance_PositiveHIGH() // Balance   - positive numbers    // should pass
        {
            double amount = 100000000.01;
            double expected = amount;
            double actual = 0.0;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", amount);

            actual = account.Balance; // expected = 100000000.01
            Assert.AreEqual(expected, actual, 0.001, "Account balance INCORRECT");
        }
        [TestMethod]
        public void Balance_Negative() // Balance    - negative numbers    // should fail
        {
            double amount = -100.01;
            double expected = amount;
            double actual = 0.0;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", amount);

            actual = account.Balance; // expected = -100.01
            Assert.AreEqual(expected, actual, 0.001, "Account balance INCORRECT"); // should fail


            double amount2 = 0.0;
            double expected2 = amount2;
            //double actual2 = 0.0;
            BankAcc4Testing account2 = new BankAcc4Testing("Mr. Steven Smith", amount2);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(amount));

            //actual2 = account2.Balance; // expected = 0.0
            //Assert.AreEqual(expected2, actual2, 0.001, "Account balance INCORRECT"); // should fail
        }
        [TestMethod]
        public void Debit_Negative() // Debit           - amount<= 0          // should fail
        {
            double amount = -101.01; // negative
            double balance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", balance);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(amount));
        }

        // Bug #1 - 0 should not be passable
        [TestMethod]
        public void Debit_Zero() // Debit        - amount = 0          // should fail
        {
            double amount = 0; // zero
            double balance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", balance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(amount)); 
        }
        [TestMethod]
        public void Debit_BalanceTooLow() // Debit           - amount > m_balance  // should fail
        {
            double amount = 101.01; // more than in account (balance)
            double balance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", balance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(amount));
            // Catch ArgumentOutOfRangeException
        }

        [TestMethod]
        public void Debit() // Debit           - amount<m_balance  // should pass (will fail due to code)
        {
            // Arrange
            double beginningBalance = 100.10;
            double debitAmount = 10.01;
            double expected = 90.09;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance; // expected = 90.09
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly"); // should pass (will fail due to code)
        }

        [TestMethod]
        public void DreditFixed_Negative() // Debit_Fixed     - amount<= 0          // should fail
        {
            double amount = -101.01; // negative
            double balance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", balance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(amount));
        }
        [TestMethod]
        public void DreditFixed_Zero() // Debit_Fixed     - amount == 0          // should fail
        {
            double amount = 0; // negative
            double balance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", balance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit_Fixed(amount));
        }
        [TestMethod]
        public void DreditFixed_BalanceTooLow() // Debit_Fixed - amount > m_balance  // should fail
        {
            double amount = 101.01; // more than in account (balance)
            double balance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", balance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit_Fixed(amount));
        }
        [TestMethod]
        public void DreditFixed() // Debit_Fixed - amount < m_balance  // should pass
        {
            double beginningBalance = 100.10;
            double debitAmount = 10.01;
            double expected = 90.09;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", beginningBalance);

            account.Debit_Fixed(debitAmount);

            double actual = account.Balance; // expected = 90.09
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly"); // should pass
        }
        [TestMethod]
        public void Credit_Negative() // Credit - negative numbers// should fail
        {
            double amount = -10.01;
            double expected = amount;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", 0);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(amount));
        }

        // Bug #2 - 0 should not be passable
        [TestMethod]
        public void Credit_Zero() // Credit - 0 number// should fail
        {
            double amount = 0;
            double expected = amount;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", 0);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(amount));
        }
        [TestMethod]
        public void Credit() // Credit - positive numbers    // should pass
        {
            double amount = 10.01;
            double expected = amount;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", 0);

            account.Credit(amount);

            double actual = account.Balance; // expected = 10.01
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly"); // should pass
        }
        [TestMethod]
        public void BankMain() // BankMain - just run and check print // should pass
        {
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", 0);
            //account.BankMain();
            BankAcc4Testing.BankMain();
            // Writeline check?

            /*
            BankAcc4Testing ba = new BankAcc4Testing("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            */
        }







        // Tutorial - https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019
        // Testing - debit account, check the remaining is correct 
        [TestMethod]
        public void TUTORIAL_FAIL_Debit_Valid_RemainingCheck()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance; // expected = 7.44
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            // this uncovers a bug with BankAcc4Testing - m_balance -= amount;
        }

        // Testing - debit account, less than 0 - Throw Argument
        [TestMethod]
        public void TUTORIAL_Debit_LessThan0_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Bryan Walton", beginningBalance);

            // Shorthand/ lambda expression?
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        // Testing - debit account, balance too low to debit - Throw Argument
        [TestMethod]
        public void TUTORIAL_Debit_BalanceTooLow_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAcc4Testing.Debit_AccTooLow_M);
            }
        }
        [TestMethod]
        public void TUTORIAL_Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double debitAmount = 101.01; // more than in account (balance)
            double beginningBalance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", beginningBalance);

            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
            // Catch ArgumentOutOfRangeException

            
            // Try to take more than is in the account
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //throw new ArgumentOutOfRangeException("amount", amount, Debit_IncorrectAmount_M);
                StringAssert.Contains(e.Message, BankAcc4Testing.Debit_AccTooLow_M);
                return; // without return, fails due to carrying on to Assert.Fail
            }
            // When no exception is thrown
            Assert.Fail("Expected exception, but exception was not thrown.");
        }
        [TestMethod]
        public void TUTORIAL_Debit_IncorrectAmount()
        {
            double debitAmount = -5;
            double beginningBalance = 100;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Steven Smith", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAcc4Testing.Debit_IncorrectAmount_M);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
