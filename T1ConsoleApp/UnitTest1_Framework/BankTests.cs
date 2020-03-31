using System;
using T1ConsoleApp; // bank account

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BankTests
    {
        // Test calc app with the Using
        [TestMethod]
        public void Something()
        {
            // Arrange
            // Act
            // Assert
            //var calc = new Calc4Testing();
            //int result = calc.Add(4, 3);
            //Assert.AreEqual(7, result);
        }

        // Test calc app without the Using set above
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

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            // this uncovers a bug with BankAcc4Testing - m_balance -= amount;
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAcc4Testing account = new BankAcc4Testing("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange2()
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
