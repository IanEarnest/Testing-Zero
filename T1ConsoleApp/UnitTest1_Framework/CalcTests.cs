using System;
using T1ConsoleApp; // calculator

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CalcTests
    {
        // Test calc app with the Using
        [TestMethod]
        public void WithUsing()
        {
            // Arrange
            // Act
            // Assert
            var calc = new Calc4Testing();
            int result = calc.Add(4, 3);
            Assert.AreEqual(7, result);
        }

        // Test calc app without the Using set above
        [TestMethod]
        public void WithoutUsing()
        {
            var calc2 = new T1ConsoleApp.Calc4Testing();
            int result = calc2.Add(4, 3);
            Assert.AreEqual(7, result);
        }
    }
}
