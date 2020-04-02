using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T2WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //input = textBox1.Text;
            //string input;
            //input = textBox1.Text;
            //MessageBox.Show(input);
            //MessageBox.Show("Hi", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        // This was made following the tutorial:
        // Calc https://www.homeandlearn.co.uk/csharp/csharp_s2p18.html
        //TODO
        // Menus? https://www.homeandlearn.co.uk/csharp/csharp_s4p1.html
        // 
        //Future
        // btnPoint_Click add check for number before
        /*1. answer in box (clears after press)
        * 2. equals pressed, repeat last
        * 3. plus pressed after equals does nothing (+ in calc box)
        * after + pressed, leave number (until number pressed)
         */


        // variables
        double numFirst = 0; // first input
        double numSecond = 0; // last input 
        double answer = 0; // answer
        string calcOperator = ""; // operator
        string calcOperatorSpace = "";
        bool equalsPressed = false;
        bool tmpAnswerInInput = false;

        // if + pressed (second time?), show answer until something pressed?
        // after equals, if a number is pressed, reset everything
        // after equals, if equals pressed, repeats last action (+)
        //                          answer += numSecond;
        //                          // numSecond = numSecond - CHANGE ELSE ABOVE?
        //                          // answer = numFirst
        //                          calculationBox.Text = answer.toString() + " + " + numSecond.toString()
        // after equals, if + pressed,
        //                          calculationBox.Text = answer.toString() + " + "
        //                          + pressed again does nothing

        // Most logic in here   
        private void preCalc(string calcOp)
        {
            calcOperator = calcOp;
            calcOperatorSpace = " " + calcOp + " "; // this means " + "

            // (stop + being repeat pressed) number pressed, plus pressed (no repeat)
            //if(lastPressed != "+")

            // When operator is pressed or equals
            // first input store in numFirst
            // second input store in numSecond
            // 
            // on second + display temp

            if (numFirst == 0) // if first input, set num1
            {
                numFirst = double.Parse(inputBox.Text);
                calculationBox.Text += numFirst + calcOperatorSpace; // e.g. 1 +
            }
            else if (numSecond == 0) // if second input, set num2
            {
                // e.g. 1 + 1 
                if (!equalsPressed)
                {
                    numSecond = double.Parse(inputBox.Text);
                    calculationBox.Text += numSecond + calcOperatorSpace; // e.g. 1 + 1
                                                               // on second + pressed, display temp answer
                                                               // same for =??
                    calculate(); // e.g. answer = numFirst + numSecond;

                    inputBox.Text = answer.ToString();
                    tmpAnswerInInput = true;

                    // instead of displaying "+ num"
                    //try displaying the full calculationBox.text then new line
                    //fullCalculationsBox.Text += numSecond + calcOperatorSpace;
                    // carry on calculating?
                }
                else // e.g. 1 + 1 =
                {
                    numSecond = double.Parse(inputBox.Text);
                    calculate(); // e.g. answer = numFirst + numSecond;

                    calculationBox.Text = numFirst + calcOperatorSpace + numSecond + " =";
                    fullCalculationsBox.Text += numFirst + calcOperatorSpace + numSecond + " = " + answer + "\n";

                    inputBox.Text = answer.ToString();
                    tmpAnswerInInput = true;
                }
            }
            // repeated =
            else if (equalsPressed) // if equals pressed set end to "=" otherwise set end to operation
            {
                // check operator
                /*
                double tmpNumFirst = answer;
                if (calcOperator == "+") answer = tmpNumFirst + numSecond;
                if (calcOperator == "-") answer = tmpNumFirst - numSecond;
                if (calcOperator == "/") answer = tmpNumFirst / numSecond;
                if (calcOperator == "*") answer = tmpNumFirst * numSecond;
                */
        numFirst = answer;
                calculate();
                // 1 + 2 + 3 = 6 changed into
                // 3 + 3

                calculationBox.Text = numFirst + calcOperatorSpace + numSecond + " =";
                fullCalculationsBox.Text += numFirst + calcOperatorSpace + numSecond + " = " + answer + "\n";

                inputBox.Text = answer.ToString(); // temp


                // DONE? after this any new number resets everything
                // after this, press + (operator) to sets numbers available and changes
                //calculationBox to answer + operator
                // 3+3 "no spaces" at some point??













                //fullCalculationsBox.Text += tmpNumFirst + calcOperatorSpace + numSecond + " = " + answer + "\n";
                //calculationBox.Text = tmpNumFirst.ToString() + calcOperatorSpace + numSecond.ToString() + " =";
                //inputBox.Text = answer.ToString(); // temp
                //fullCalculationsBox.Text += calculationBox.Text + answer + "\n";

                // after equals pressed, start again
                //reset();
                //equalsPressed = false;
                //answer += numSecond;
                //answer = numFirst;
                // after this, if + pressed, do nothing 
                // when is equalsPressed = false?
            }
            else // if both first and second numbers set
            {
                // if + pressed when answer = numFirst + numSecond;
                // then don't calculate again

                // 1+1 +2????
                // plus/ operator or equals pressed?


                // set first number to a pre calculation of the two numbers
                // set numSecond to input

                //fullCalculationsBox.Text = "1. " + numFirst + ", " + numSecond + ", " + tmp + ", " + answer;

                // if operation not repeated on same numbers (what if user presses same number again?)
                // and user has pressed a number
                //answer != (numFirst + numSecond) &&
                if (tmpAnswerInInput == false)
                {
                    //fullCalculationsBox.Text = "2. " + numFirst + ", " + numSecond + ", " + answer;

                    // keep calculating
                    // set first number to a pre calculation of the two numbers
                    // set numSecond to input
                    if (calcOp == "+") numFirst = numFirst + numSecond;
                    if (calcOp == "-") numFirst = numFirst - numSecond;
                    if (calcOp == "/") numFirst = numFirst / numSecond;
                    if (calcOp == "*") numFirst = numFirst * numSecond;
                    numSecond = double.Parse(inputBox.Text);
                    calculate();

                    
                    inputBox.Text = answer.ToString();
                    tmpAnswerInInput = true;
                    calculationBox.Text += numSecond + calcOperatorSpace;


                    // instead of displaying "+ num"
                    //try displaying the full calculationBox.text then new line
                    //fullCalculationsBox.Text += numSecond + calcOperatorSpace;//+ " " + calcOp + " ";



                }
            }

            //equals
            // after every input, delete last input
            tmpAnswerInInput = true;
        }

        // checked on every number, if answer is visible, delete
        private void tmpAnswerCheck()
        {
            if(tmpAnswerInInput)
            {
              inputBox.Text = "";
              //calculationBox.Text = "";
              tmpAnswerInInput = false;

                // after digit is pressed after equals has been pressed
                if (equalsPressed)
                {
                    // not running??
                    reset();
                }
            }
        }

        private void reset()
        {
            numFirst = 0;
            numSecond = 0;
            answer = 0;
            inputBox.Text = "";
            calculationBox.Text = "";
            equalsPressed = false;
        }

        private void calculate()
        {
            // calculate answer
            if (calcOperator == "+") answer = numFirst + numSecond;
            if (calcOperator == "-") answer = numFirst - numSecond;
            if (calcOperator == "/") answer = numFirst / numSecond;
            if (calcOperator == "*") answer = numFirst * numSecond;
        }




        // clear buttons
        // go back one character
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            String tmpInput = inputBox.Text;
            String newString = "";
            //answerBox.Text.Length = answerBox.Text.Length - 1;
            // Only remove last letter if the letter exists (otherwise would have error)
            if (tmpInput.Length > 0)
            {
                newString = tmpInput.Substring(0, (tmpInput.Length - 1));
            }
            inputBox.Text = newString;
        }
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            inputBox.Text = ""; //textBox1.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            numFirst = 0;
            numSecond = 0;
            answer = 0;
            inputBox.Text = "";
            calculationBox.Text = "";
        }


        // buttons 1-9
        private void btn1_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "1";
        }

        // buttons
        private void btn2_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            inputBox.Text += "0";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            tmpAnswerCheck();
            // need to add check number is here before adding point
            inputBox.Text += ".";
        }

        // Equals button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            equalsPressed = true;
            preCalc(calcOperator);
            //2.equals pressed, repeat last
            // check answer is not empty, check operator
            // repeat calculation
            /*
            if (numSecond == 0) // if no answer yet, calculate
            {
                equalsPressed = true;
                preCalc(calcOperator);
            }
            else if (answer != 0 && equalsPressed)// if already answer, repeat last calculation
            {
                // check operator
                double tmpNumFirst = answer;
                if (calcOperator == "+") answer = tmpNumFirst + numSecond;
                if (calcOperator == "-") answer = tmpNumFirst - numSecond;
                if (calcOperator == "/") answer = tmpNumFirst / numSecond;
                if (calcOperator == "*") answer = tmpNumFirst * numSecond;
                
                // e.g. 1 + 2 = 3
                //fullCalculationsBox.Text += tmpNumFirst + calcOperatorSpace + numSecond + " = " + answer + "\n";
                calculationBox.Text = tmpNumFirst.ToString() + calcOperatorSpace + numSecond.ToString() + " =";
                inputBox.Text = answer.ToString(); // temp
                fullCalculationsBox.Text += calculationBox.Text + answer + "\n";
                // after equals pressed, start again
                reset();
                equalsPressed = false;
                //answer += numSecond;
                //answer = numFirst;
                // after this, if + pressed, do nothing 
                // when is equalsPressed = false?;
            }*/
        }

        

        // operators
        private void btnPlus_Click(object sender, EventArgs e)
        {
            preCalc("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            preCalc("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            preCalc("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            preCalc("/");
        }

        
        // make positive number negative and vice versa (1 = -1 or -1 = 1)
        private void btnInvert_Click(object sender, EventArgs e)
        {
            // get input value, set value to *-1 (reverse), display value
            if(inputBox.Text != "") { 
                double tmpNum =  double.Parse(inputBox.Text);
                tmpNum = tmpNum * -1; // 
                inputBox.Text = tmpNum.ToString();
            }
        }


        // rich text box (full calculations box) buttons
        // btn clear, btn extend, btn shrink
        private void btnExtend_Click(object sender, EventArgs e)
        {
            fullCalculationsBox.Height = 232; //285
        }

        private void btnShrink_Click(object sender, EventArgs e)
        {
            fullCalculationsBox.Height = 56;
        }

        private void btnClearRich_Click(object sender, EventArgs e)
        {
            fullCalculationsBox.Text = "";
        }
    }
}
