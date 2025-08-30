using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double value1 = 0;
        private string operation = "";
        private bool newInput = true;

        public Form1()
        {
            InitializeComponent();
        }

        // Handle number button clicks
        private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (txtDisplay.Text == "0" || newInput)
                txtDisplay.Text = "";
            txtDisplay.Text += b.Text;
            newInput = false;
        }

        // Handle operator button clicks (+, -, ×, ÷)
        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            value1 = double.Parse(txtDisplay.Text);
            operation = b.Text;
            newInput = true;
        }

        // Handle clear button (C)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            value1 = 0;
            operation = "";
            newInput = true;
        }

        // Handle equal button (=)
        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                double value2 = double.Parse(txtDisplay.Text);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = value1 + value2;
                        break;
                    case "-":
                        result = value1 - value2;
                        break;
                    case "×":
                        result = value1 * value2;
                        break;
                    case "÷":
                        if (value2 == 0)
                        {
                            txtDisplay.Text = "Error";
                            return;
                        }
                        result = value1 / value2;
                        break;
                    default:
                        return;
                }

                txtDisplay.Text = result.ToString();
                newInput = true;
            }
            catch
            {
                txtDisplay.Text = "Error";
                newInput = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
