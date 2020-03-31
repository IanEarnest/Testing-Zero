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
                Assert.Fail(); //
            }
            //Console.WriteLine("Current balance is ${0}", ba.Balance); //
            
        }
    }
}
