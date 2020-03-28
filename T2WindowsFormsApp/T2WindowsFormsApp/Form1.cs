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

        //TODO
        // Calc https://www.homeandlearn.co.uk/csharp/csharp_s2p18.html
        // Menus? https://www.homeandlearn.co.uk/csharp/csharp_s4p1.html

        //string input;
        private void btn1_Click(object sender, EventArgs e)
        {
            answerBox.Text += "1";
            //input = textBox1.Text;
            //string input;
            //input = textBox1.Text;
            //MessageBox.Show(input);
            //MessageBox.Show("Hi", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            answerBox.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            answerBox.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            answerBox.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            answerBox.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            answerBox.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            answerBox.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            answerBox.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            answerBox.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            answerBox.Text += "0";
        }

        private void btnDOT_Click(object sender, EventArgs e)
        {
            answerBox.Text += ".";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            String tmpAnswer = answerBox.Text;
            String newAnswerBox = "";
            //answerBox.Text.Length = answerBox.Text.Length - 1;
            // Only remove last letter if the letter exists (otherwise would have error)
            if (tmpAnswer.Length > 0) { 
                newAnswerBox = tmpAnswer.Substring(0, (tmpAnswer.Length - 1));
            }
            answerBox.Text = newAnswerBox;
        }
        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            answerBox.Text = ""; //textBox1.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            answerBox.Text = "";
            calculationBox.Text = "";
        }


        double num1 = 0; // add num
        double num2 = 0; // answer?
        private void btnEquals_Click(object sender, EventArgs e)
        {
            num2 = num1 + double.Parse(answerBox.Text);
            answerBox.Text = num2.ToString(); // show answer
            //answerBox.Text = "";
            num1 = 0;
            fullCalculationsBox.Text += num1 + " + " + answerBox.Text + " = " + num2 + "\n";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

            // get box number (double)
            // add to second number (if any)
            // 
            //String tmpAnswer = answerBox.Text;
            double tmpNum1 = double.Parse(answerBox.Text);
            double tmpAnswer = num1 + tmpNum1;
            fullCalculationsBox.Text += num1 + " + " + tmpNum1 + " = " + tmpAnswer + "\n";


            //tmpNum1
            num1 += tmpNum1;
            calculationBox.Text += tmpNum1 + "+";
            
            
            answerBox.Text = ""; // if + pressed second time, show answer until something pressed?
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            //?
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            //?
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            //?
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            // number = minus (true)?
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            answerBox.Text = ""+fullCalculationsBox.Height;
            fullCalculationsBox.Height = 232; //285
            //button18.Visible = false; //shrink
            //button19.Visible = true;
            // fullcalculationsbox size = 100, 311
            // hide btnShrink
            // show btnExtend
        }

        private void btnShrink_Click(object sender, EventArgs e)
        {
            fullCalculationsBox.Height = 56;
            //button18.Visible = true; //shrink
            //button19.Visible = false;
            // fullcalculationsbox size = 100, 56
            // hide btnShrink
            // show btnExtend
        }
    }
}
