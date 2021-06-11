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
        double firstNumber, secondNumber;
        char operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            if(result.Text.Length == 0 && button.Text == "0")
            {
                result.Text = "";
            }
            else
            {
                result.Text += button.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Numbers();

            Button button = (Button)sender;
            Operators(button);

            result.Clear();
        }
       
        private void plusorminus_b_Click(object sender, EventArgs e)
        {
            double negative = -double.Parse(result.Text);
            result.Text = negative.ToString();
        }

        private void equals_b_Click(object sender, EventArgs e)
        {
            Numbers();
            Output();
            operation = (char)default;
            secondNumber = default(double);
        }

        private void Numbers()
        {
            if (operation == default(char))
            {
                firstNumber = double.Parse(result.Text);
                MessageBox.Show("1: " + firstNumber.ToString());
            }
            else
            {
                secondNumber = double.Parse(result.Text);
                MessageBox.Show("2: " + secondNumber.ToString());

            }
        }

        private void Output()
        {
            switch (operation)
            {
                case '+':
                    result.Text = (firstNumber + secondNumber).ToString();
                    break;
                case '-':
                    result.Text = (firstNumber - secondNumber).ToString();
                    break;
                case '*':
                    result.Text = (firstNumber * secondNumber).ToString();
                    break;
                case '/':
                    if (secondNumber != 0)
                    {
                        result.Text = (firstNumber / secondNumber).ToString();
                    }
                    else
                    {
                        result.Text = "Cannot divide by zero";
                    }
                    break;
            }
        }

        private void Operators(Button button)
        {
            switch (button.Text)
            {
                case "÷":
                    operation = '/';
                    break;
                case "x":
                    operation = '*';
                    break;
                case "√x":
                    result.Text = Math.Sqrt(firstNumber).ToString();
                    break;
                case "x ^ 2":
                    result.Text = Math.Pow(firstNumber, 2).ToString();
                    break;
                case "1 / x":
                    result.Text = (1 / firstNumber).ToString();
                    break;
                case "%":
                    result.Text = (firstNumber / 100).ToString();
                    break;
                case "CE":
                    result.Clear();
                    break;
                case "C":
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                    break;
                case "<-":
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                    break;
                default:
                    operation = char.Parse(button.Text);
                    break;
            }
        }
    }
}
