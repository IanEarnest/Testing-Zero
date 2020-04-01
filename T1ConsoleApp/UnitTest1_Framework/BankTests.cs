using System;
using T1ConsoleApp; // bank account

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BankTests
    {
        // Testing - credit a new account
        [TestMethod]
        public void Credit()
        {
            BankAcc4Testing ba = new BankAcc4Testing("Mr. Bryan Walton", 1);

            ba.Credit(5.77);
            //ba.Debit(11.22); //  Assert.Fail();
            try
            {
                ba.Debit(11.22);
               
            } catch
            {
                //Assert.Fail(); //
            }
        }


        // Testing - debit account, check the remaining is correct 
        [TestMethod]
        public void Debit_Valid_RemainingCheck()
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
        public void Debit_LessThan0_ShouldThrowArgumentOutOfRange()
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
        public void Debit_BalanceTooLow_ShouldThrowArgumentOutOfRange()
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
                //StringAssert.Contains(e.Message, BankAcc4Testing.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
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
                //StringAssert.Contains(e.Message, BankAcc4Testing.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
