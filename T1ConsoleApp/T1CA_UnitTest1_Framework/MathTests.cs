using System;
using T1ConsoleApp; // math
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MathTests
    {

        /*- Testing - BankAcc4Testing
What does it do - create new account and change balance

Variables = m_customerName (CustomerName func - returns customerName)
            m_balance (Balance func - returns customerName)

Functions = BankAcc4Testing (customerName, balance) - create account
	        CustomerName, Balance   - returns variables (fields?)
            Debit (amount)          - reduce m_balance by ammount

Tests = 17 (+4 tutorial = 21)
CustomerName    - name                // should pass
         */

        /*
Expected fails = 4 (+1 tutorial = 5)
Debit               - Bug #1 IGNORE(fixed in Debit_Fixed)
     */
        /*
           [TestMethod]
           public void CustomerName()
           {
               string name = "Mr. Steven Smith";
               string expected = name;
               string actual = "";
               BankAcc_Testing account = new BankAcc_Testing(name, 0);

               actual = account.CustomerName; // expected = Mr. Steven Smith
               Assert.AreEqual(expected, actual, true, "Account named INCORRECTLY");
           }
           */
        [TestMethod]
        public void BasicRooterTest()
        {
            // Create an instance to test:
            MyMath_Testing rooter = new MyMath_Testing();
            // Define a test input and output value:
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            // Run the method under test:
            double actualResult = rooter.SquareRoot(input);
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        [TestMethod]
        public void RooterValueRange()
        {
            // Create an instance to test.
            MyMath_Testing rooter = new MyMath_Testing();

            // Try a range of values.
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(MyMath_Testing rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;// 2 * 2 = 4
            double actualResult = rooter.SquareRoot(input); // 4 / 2 = 2
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000); // 100 = 0.1?
        }

        [TestMethod]
        public void RooterTestNegativeInputx()
        {
            // stuck in loop
            MyMath_Testing rooter = new MyMath_Testing();
            try
            {
                rooter.SquareRoot(-10);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }
    }
}
