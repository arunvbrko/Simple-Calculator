using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator,n2,n1;
        double number1, number2;
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }
        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            double val;
            if (double.TryParse(this.resultText.Text, out val))
            {
                this.resultText.Text = n1+val.ToString("N0");
                
                if (currentState == 1)
                {
                    number1 = val;
                }
                else
                {
                    n2 = this.resultText.Text;
                    number2 = val;
                }
            }
        }
        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
            n1=this.resultText.Text += mathOperator;
        }
        void OnClear(object sender, EventArgs e)
        {
            number1 = 0;
            number2 = 0;
            currentState = 1;
            this.resultText.Text = "0";
            n2 = "";
            n1 = "";
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Calculate(number1, number2, mathOperator);

                this.resultText.Text = n2+"="+result.ToString();
                number1 = result;
                currentState = -1;
                n2 = "";
                n1 = "";
            }
        }
        public static double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "×":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }

            return result;
        }
    }
}
