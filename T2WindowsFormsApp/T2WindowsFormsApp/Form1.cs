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
            // shrink hide
        }

        // This was made following the tutorial:
        // Calc https://www.homeandlearn.co.uk/csharp/csharp_s2p18.html
        //TODO
        // Menus? https://www.homeandlearn.co.uk/csharp/csharp_s4p1.html
        // After = press number to reset
        //string input;


        // variables
        double numFirst = 0; // first input
        double numSecond = 0; // last input 
        double answer = 0; // answer
        string lastPressed = ""; // operator

        // answer in box

        //next number clears box
        //numFirst = 0;
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
        private void preCalc(string calcOperator)
        {
            // if + pressed (second time?), show answer until something pressed?
            //inputBox.Text = answer.ToString();
            //tmpAnswerInInput = true

            if (numFirst == 0) // if first input, set num1
            {
                numFirst = double.Parse(inputBox.Text);
                calculationBox.Text += numFirst + calcOperator;
            }
            else if (numSecond == 0)
            {
                numSecond = double.Parse(inputBox.Text);
                calculationBox.Text += numSecond + calcOperator;
            }
            else // if both first and second numbers set
            {
                if (calcOperator == "+") numFirst = numFirst + numSecond;
                if (calcOperator == "-") numFirst = numFirst - numSecond;
                if (calcOperator == "/") numFirst = numFirst / numSecond;
                if (calcOperator == "*") numFirst = numFirst * numSecond;
                //numFirst = 0;
                numSecond = double.Parse(inputBox.Text);
                calculationBox.Text += numSecond + calcOperator;
            }


            string calcOperatorSpace = " " + calcOperator + " "; // this means " + "
            if (calcOperator == "+")
            {
                answer = numFirst + numSecond;
            }
            if (calcOperator == "-") answer = numFirst - numSecond;
            if (calcOperator == "/") answer = numFirst / numSecond;
            if (calcOperator == "*") answer = numFirst * numSecond;

            lastPressed = calcOperator;
            fullCalculationsBox.Text += numFirst + calcOperatorSpace + numSecond + " = " + answer + "\n";
            inputBox.Text = "";
        }


        private void tmpAnswerCheck()
        {
            //if(tmpAnswerInInput)
            //{
            // inputBox.Text = "";
            // tmpAnswerInInput = false;
            //}
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
            //tmpAnswerCheck()
            inputBox.Text += "1";
            //input = textBox1.Text;
            //string input;
            //input = textBox1.Text;
            //MessageBox.Show(input);
            //MessageBox.Show("Hi", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        // buttons
        private void btn2_Click(object sender, EventArgs e)
        {
            inputBox.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            inputBox.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            inputBox.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            inputBox.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            inputBox.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            inputBox.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            inputBox.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            inputBox.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            inputBox.Text += "0";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            inputBox.Text += ".";
        }

        // Equals button
        private void btnEquals_Click(object sender, EventArgs e)
        {
            preCalc(lastPressed);
            inputBox.Text = answer.ToString(); // temp
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
            double tmpNum =  double.Parse(inputBox.Text);
            tmpNum = tmpNum * -1; // 
            inputBox.Text = tmpNum.ToString();
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
