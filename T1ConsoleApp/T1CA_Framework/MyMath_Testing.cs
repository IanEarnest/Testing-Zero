using System;

// Test driven development tutorial
// https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2019

namespace T1ConsoleApp
{

    // Overview
    /* Main()           = Read user input, check for letters, perform calculation, restart
     * Calculate()      = take user input and operation then use FindNumbers and calculate then display result
     * FindNumbers()    = iterate through user input, return both first and second number
     */
    public class MyMath_Testing
    {
        /*static void Main()
        {
            // Start of program

        }*/

        public double SquareRoot(double input)
        {
            // return input / 2; // old

            // Stop loop
            if (input <= 0.0)
            {
                throw new ArgumentOutOfRangeException();
            }

            // while 0 less than 5 (example)
            double result = input;
            double previousResult = -input;
            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = (result + input / result) / 2;
                //was: result = result - (result * result - input) / (2*result);
            }
            return result;

            /*
            double result = input; // 100
            double previousResult = -input; // -100
            while (Math.Abs(-100 - 100) > result / 1000)    // = -200 < 0.01 (100 / 1000 = 0.1)
            {
                previousResult = result; // -200 = 100
                //result = (result + input / result) / 2; // 50.5 = 101/2, 101 = (100 + 1 (100/100)
                result = result - (result * result - input) / (2 * result); // 51.5 = 100 - 49.5 = (100*100 = 10k - 100 = 9.9k) / 200
            }
            return result; // 51.5
            */
        }
    }
}