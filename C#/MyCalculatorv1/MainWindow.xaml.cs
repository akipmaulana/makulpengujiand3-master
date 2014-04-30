//houssem.dellai@ieee.org 
//+216 95 325 964 

using System;
using System.Windows;
using System.Windows.Controls;

namespace MyCalculatorv1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //get text of button. kemudian masukan textnya kedalam tb.
            Button b = (Button) sender;
            tb.Text += b.Content.ToString();
        }

        public void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception exc)
            {
                tb.Text = "Error!";
            }
        }

        private void result()
        {
            String op;
            int iOp = 0;
            if (tb.Text.Contains("+"))
            {
                //mencari index dari karakter '+' pada string tb.
                iOp = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                iOp = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("*"))
            {
                iOp = tb.Text.IndexOf("*");
            }
            else if (tb.Text.Contains("/"))
            {
                iOp = tb.Text.IndexOf("/");
            }
            else
            {
                //error
            }
            
            //get karakter operator
            op = tb.Text.Substring(iOp, 1);
            //get operan1
            double op1 = Convert.ToDouble(tb.Text.Substring(0, iOp));
            //get operan2
            double op2 = Convert.ToDouble(tb.Text.Substring(iOp + 1, tb.Text.Length - iOp - 1));

            if (op == "+")//add
            {
                tb.Text += "=" + Add(op1,op2);
            }
            else if (op == "-")//substract
            {
                tb.Text += "=" + Substract(op1, op2);
            }
            else if (op == "*")//multiply
            {
                tb.Text += "=" + Multiply(op1, op2);
            }
            else // divide
            {
                tb.Text += "=" + Divide(op1, op2);
            }
        }

        #region operasi

        public double Add(double op1, double op2)
        {
            return (op1 + op2);
        }

        public double Substract(double op1, double op2)
        {
            return (op1 - op2);
        }

        public double Multiply(double op1, double op2)
        {
            return (op1 * op2);
        }

        public double Divide(double op1, double op2)
        {
            return (op1 / op2);
        }

        #endregion

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }

        public void R_Click(object sender, RoutedEventArgs e)
        {
            if (tb.Text.Length > 0)
            {
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);
            }
        }
    }
}
