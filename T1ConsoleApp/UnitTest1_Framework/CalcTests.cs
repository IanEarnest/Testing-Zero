using System;
using T1ConsoleApp; // bank account

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            // Act
            // Assert
            var calc = new Calculator();
            var calc2 = new T1ConsoleApp.Calculator();

            int result = calc.Add(4, 3);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            // Act
            // Assert
            var calc = new Calculator();
            var calc2 = new T1ConsoleApp.Calculator();

            int result = calc2.Add(4, 3);

            Assert.AreEqual(8, result); // intentially false
        }
    }
}
