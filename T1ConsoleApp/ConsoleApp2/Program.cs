using System;

// Program ideas
// 1. Calculator // https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019
// TODO - seperate into functions/ sperate files?, change to public/ not static?
// 2. Another app??? - try out Visual C# - https://www.homeandlearn.co.uk/csharp/csharp_s1p8.html
//ideas - https://www.javatpoint.com/csharp-programs
//- https://www.javatpoint.com/csharp-program-to-convert-number-in-characters
// next?
namespace T1ConsoleApp
{
    class Program
    {
        
        

        static string input = ""; // user input
        static bool validInput = true; // text filter

        // Read user input
        // check for letters (invalid)
        // perform calculation (+ or -)
        // restart program
        static void Main() // private static void Main(string[] args)
        {

            // Unit test example 1
            //Calculator calc = new Calculator();
            var calculator = new Calculator();

            int result = calculator.Add(5, 6);

            if (result != 11)
                throw new InvalidOperationException();
            // end of test
            
            /*
            var ba = new BankAccount("A",1);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            */

            // Start of program
            // User instructions, read user input
            Console.WriteLine("Hello World! - Console Calculator App");
            Console.WriteLine("Enter calculation and press Enter... e.g. 1+1"); // user inputs numbers + arithmatic (+, -)
            input = Console.ReadLine(); // read user input


            // Error checking
            // Filter to find any letters (don't belong)
            // Loop prints all inputs, if letter is found then validInput = false 
            //Console.Write("Length = " + input.Length + " - "); // Debug
            for (int i = 0; i < input.Length; i++) // i = character, loop through until last letter of input
            {
                //Console.Write("i" + i + "=" + input[i] + " "); // Debug
                // Check each character
                // If letter and not number or +/-, restart program
                if (Char.IsLetter(input[i]))
                {
                    //Console.WriteLine(""); // space between
                    Console.WriteLine("'" + input + "'" + " is NOT a number!"); // Error
                    Console.WriteLine("");
                    validInput = false;
                    //return;
                    Program.Main();
                }
            }
            //Console.WriteLine(""); // space between numbers and "Add" or "Sub" // Debug

            // Outside of error checking (loop though letters) 
            // Once either - program restarted due to letter
            //            - or valid input, then carry on
            // if not letter (valid input = true)
            // check for + or - (and do calculation)
            if (validInput)
            {
                // do calculation of the Operation found
                if (input.Contains("+"))      Calculate(input, '+'); // Addition
                else if (input.Contains("-")) Calculate(input, '-'); // Subtraction
                else if (input.Contains("/")) Calculate(input, '/'); // Division
                else if (input.Contains("*")) Calculate(input, '*'); // Multiplication
            }

            // after addition or subtraction finished
            Program.Main(); // Restart program
        }

        public static void Calculate(string input, char op)
        {
            // Get numbers from input
            // operation
            // display result
            int[] returnVal = new int[] { 0, 0 };
            double result = 0; // double allows division
            returnVal = FindNumbers(input);
            
            // check for each operator
            // calculate
            if (op == '+') result = returnVal[0] + returnVal[1];
            else if (op == '-') result = returnVal[0] - returnVal[1];
            else if (op == '/') result = (double)returnVal[0] / (double)returnVal[1]; // // double allows division
            else if (op == '*') result = returnVal[0] * returnVal[1];

            Console.WriteLine("= " + result);
            Console.WriteLine("");
        }

        public static int[] FindNumbers(string uInput)
        {
            // Find start/ end of first number
            int num1 = 0;
            int num2 = 0;
            string n1 = ""; // num1 in String
            string n2 = ""; // num2 in String
            int symIndex = 0; // symbol position in the user input String


            // loop through characters from input
            for (int i = 0; i < uInput.Length; i++) // i = number
            {
                // find + or - symbol
                if (uInput[i] == '+' || uInput[i] == '-' || uInput[i] == '/' || uInput[i] == '*') // if symbol, stop
                {
                    symIndex = i;
                    //Console.WriteLine("symIndex= " + symIndex); // Debug

                    // set first number
                    //first number = input[0] until input[i-1]
                    for (int j = 0; j < i; j++) // until j hits i (numbers hit symbol)
                    {
                        // add to String each character this is a number 
                        //before the symbol
                        n1 += Char.GetNumericValue(uInput[j]); //(int)Char.GetNumericValue(input[j]);
                        //Console.WriteLine("j = " + input[j]); // Debug
                    }

                    // set second number
                    //second number = input[i+1] util input.length
                    // add to String each character this is a number 
                    //after the symbol
                    for (int k = i + 1; k < uInput.Length; k++) // until end of line (user input)
                    {
                        n2 += Char.GetNumericValue(uInput[k]);
                    }

                    // Set integer to the String values
                    num1 = Int32.Parse(n1);
                    num2 = Int32.Parse(n2); // crashes when only one number is submitted
                }
            }

            // after num1 and num2 set to numbers
            //return numbers as integer array
            int[] returnVal = new int[] { num1, num2 };
            return returnVal;
        }
    }
}
