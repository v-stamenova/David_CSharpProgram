using System;
using System.Windows.Forms;

namespace Factorial
{
    public partial class FactorialForm : Form
    {
        int number;

        public FactorialForm()
        {
            InitializeComponent();
        }

        private void selectNumber_ValueChanged(object sender, EventArgs e)
        {
            number = (int)Math.Round(selectNumber.Value, 0);
        }

        private void iterationButton_Click(object sender, EventArgs e)
        {
            ulong factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= (ulong)i;
            }

            label1.Text = $"{number}! = {factorial}";
        }

        private void recursionButton_Click(object sender, EventArgs e)
        {
            ulong factorial = GetFactorialRecursively(number);

            label1.Text = $"{number}! = {factorial}";
        }

        private ulong GetFactorialRecursively(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return (ulong)number * GetFactorialRecursively(number - 1);
            }
        }
    }
}
