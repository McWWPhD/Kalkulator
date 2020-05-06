using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public double arg1, arg2, result;
        StringBuilder equation = new StringBuilder();
        bool operProvided = false;
        bool operationEnded = false;
        char oper;
        List<double> elements = new List<double>();
        Math calculation = new Math();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMath.Text = "0";
        }
        
        private void but_Click(object sender, EventArgs e)
        {
            if (txtMath.Text == "0" || operProvided==true)
            {
                txtMath.Clear();
            }
            else if (operationEnded==true)
            {
                txtMath.Clear();
                lbl.Text = null;
                operProvided = false;
                equation.Clear();
                elements.Clear();
                result = 0;
                operationEnded = false;
            }
            operProvided = false;
            Button buttonClick = (Button)sender;
            txtMath.Text += buttonClick.Tag;
            equation.Append(buttonClick.Tag);

        }

        private void txtMath_TextChanged(object sender, EventArgs e)
        {


        }


        private void operClick(object sender, EventArgs e)
        {
            
            Button operButtonClick = (Button)sender;
            if (lbl.Text==null)
            {
                lbl.Text = "0" + operButtonClick.Tag;
            }
            equation.Append(operButtonClick.Tag);


            lbl.Text = equation.ToString();
            oper = Convert.ToChar(operButtonClick.Tag);
            operProvided = true;

        }

        private void butC_Click(object sender, EventArgs e)
        {
            txtMath.Text = "0";
            lbl.Text = null;
            equation.Clear();
            elements.Clear();
        }

        private void butCE_Click(object sender, EventArgs e)
        {
            txtMath.Text = "0";
            equation.Remove(equation.Length - 1, 1);
            lbl.Text = equation.ToString();
        }

        private void operEquals(object sender, EventArgs e)
        {
            Button buttoClick = (Button)sender;
            lbl.Text = equation.ToString() + "=";
            foreach (var element in equation.ToString().Split(new char[] { '+', '-', '*', '/'}) )
            {
                elements.Add(Convert.ToDouble(element.Trim().Replace('.', ',') ) );
            }

            result = calculation.Calculations((double)elements[0], (double)elements[1], oper);

            txtMath.Text = Convert.ToString(result);
            operationEnded = true;
        }


    }

}
