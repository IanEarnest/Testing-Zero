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


        //TODO
        // Calc https://www.homeandlearn.co.uk/csharp/csharp_s2p18.html
        // Menus? https://www.homeandlearn.co.uk/csharp/csharp_s4p1.html
        private void button1_Click(object sender, EventArgs e)
        {
            string input;
            input = textBox1.Text;
            MessageBox.Show(input);
            //MessageBox.Show("Hi", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            string input;
            input = textBox1.Text;
            MessageBox.Show(input);
            //MessageBox.Show("Hi", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
