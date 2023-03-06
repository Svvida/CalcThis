using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.Button;

namespace CalcThis
{
    public partial class CalcThisForm : Form
    {
        Double result = 0;
        String currentOpeartion = "";
        bool isOperationPerformed = false;

        public CalcThisForm()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (txtBoxOutput.Text == "" || isOperationPerformed) txtBoxOutput.Clear();

            isOperationPerformed = false;
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (button.Text == ".")
            {
                if (!txtBoxOutput.Text.Contains("."))
                {
                    txtBoxOutput.Text += button.Text;
                }
            }
            else
                txtBoxOutput.Text += button.Text;
        }

        private void txtBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxOutput.Clear();
            result = 0;
            lblCurrentOpearion.Text = "";
        }

        private void btnOperator(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            if (result != 0)
            {
                btnEqual.PerformClick();
                currentOpeartion = button.Text;
                isOperationPerformed = true;
                lblCurrentOpearion.Text += result + " " + currentOpeartion;
            }
            else
            {
                try
                {
                    currentOpeartion = button.Text;
                    result = Double.Parse(txtBoxOutput.Text);
                    isOperationPerformed = true;
                    lblCurrentOpearion.Text += result + " " + currentOpeartion;
                }
                catch (Exception) { MessageBox.Show("Error"); }
            }


        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (txtBoxOutput.Text != "")
            {
                switch (currentOpeartion)
                {
                    case "+":
                        txtBoxOutput.Text = (result + Double.Parse(txtBoxOutput.Text)).ToString();
                        currentOpeartion = "";
                        break;
                    case "-":
                        txtBoxOutput.Text = (result - Double.Parse(txtBoxOutput.Text)).ToString();
                        currentOpeartion = "";
                        break;
                    case "*":
                        txtBoxOutput.Text = (result * Double.Parse(txtBoxOutput.Text)).ToString();
                        currentOpeartion = "";
                        break;
                    case "/":
                        txtBoxOutput.Text = (result / Double.Parse(txtBoxOutput.Text)).ToString();
                        currentOpeartion = "";
                        break;
                    default:
                        break;
                }
                result = Double.Parse(txtBoxOutput.Text);
                lblCurrentOpearion.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtBoxOutput.Text.Length > 0)
            {
                txtBoxOutput.Text = txtBoxOutput.Text.Remove(txtBoxOutput.Text.Length - 1);
            }
        }
    }
}