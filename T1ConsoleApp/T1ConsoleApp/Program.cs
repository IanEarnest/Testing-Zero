using System;

// Program ideas
// 1. Calculator // https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019
// TODO - seperate into functions/ sperate files?
// 2. Another app??? - try out Visual C# - https://www.homeandlearn.co.uk/csharp/csharp_s1p8.html
//ideas - https://www.javatpoint.com/csharp-programs
//- https://www.javatpoint.com/csharp-program-to-convert-number-in-characters
namespace T1ConsoleApp
{
    class Program
    {
        static void Main() // private static void Main(string[] args)
        {
            string input = ""; // user input
            bool validInput = true;


            Console.WriteLine("Enter calculation... e.g. 1+1"); // user inputs numbers + arithmatic (+, -)
            input = Console.ReadLine(); // read user input

            // filter to find any letters (don't belong)
            // Loop prints all inputs, false validInput if letter is found

            //Console.Write("Length = " + input.Length + " - "); // Debug
            for (int i = 0; i < input.Length; i++) // i = character
            {
                //Console.Write("i" + i + "=" + input[i] + " "); // Debug

                // if letter and not number or +/-
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


            if (validInput)
            {
                if (input.Contains("+"))
                {
                    Add(input); // Addition
                }
                else if (input.Contains("-"))
                {
                    Sub(input); // Subtraction
                }
            }
            /*
            Console.WriteLine("Hello World! - Console Calculator App");
            Console.WriteLine("Enter number: ");
            Console.ReadLine();
            */

            Program.Main(); // Restart program
        }

        public static void Add(string input)
        {
            int[] returnVal = new int[] { 0, 0 };
            returnVal = FindNumbers(input);
            int result = returnVal[0] + returnVal[1];
            Console.WriteLine("= " + result);
            Console.WriteLine("");
        }


        public static void Sub(string input)
        {
            int[] returnVal = new int[] { 0, 0 };
            returnVal = FindNumbers(input);
            int result = returnVal[0] - returnVal[1];
            Console.WriteLine("= " + result);
            Console.WriteLine("");
        }

        public static int[] FindNumbers(string input)
        {
            // Find start/ end of first number
            int num1 = 0;
            int num2 = 0;
            int result = 0;
            int symIndex = 0;

            for (int i = 0; i < input.Length; i++) // i = number
            {
                if (input[i] == '+' || input[i] == '-') // if symbol, stop
                {

                    symIndex = i;
                    //Console.WriteLine("symIndex= " + symIndex); // Debug
                    //input[0] until input[i-1] is first number
                    //input[i+1] util input.length = second number

                    string n1 = "";
                    for (int j = 0; j < i; j++) // until j hits i (numbers hit symbol)
                    {
                        n1 += Char.GetNumericValue(input[j]); //(int)Char.GetNumericValue(input[j]);
                        //Console.WriteLine("j = " + input[j]); // Debug
                    }
                    string n2 = "";
                    for (int k = i + 1; k < input.Length; k++) // until end of line
                    {
                        n2 += Char.GetNumericValue(input[k]);
                        //Console.WriteLine("k = " + input[k]); // Debug
                    }
                    num1 = Int32.Parse(n1);
                    num2 = Int32.Parse(n2);
                }
            }



            //result = num1 + num2;
            //Console.WriteLine("(n1) " + num1 + " + (n2) " + num2 +  " = " + result); // Debug
            //Console.WriteLine("= " + result);
            //Console.WriteLine("");
            //Console.ReadLine();
            int[] returnVal = new int[] { num1, num2 };
            return returnVal;
        }
    }
}
