using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        string var1 = "";
        string var2 = "";
        bool buttonClick = false;
        bool operationPressed = false;
        bool buttonEqualPressed = false;
        string operation = "";
        public Calculator()
        {
            InitializeComponent();
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (textBoxData.Text != "")
                textBoxData.Text = Convert.ToString(-Convert.ToDouble(textBoxData.Text));
            else
                SystemSounds.Hand.Play();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // if (var2 == "" || !operationPressed && !buttonEqualPressed) var2 = textBoxData.Text;

            if (!buttonEqualPressed) var2 = textBoxData.Text;

            if (!operationPressed) labelMeanchwileWalue.Text = $"{var1} {operation} {var2} = ";
            if (var1 == "" || var2 == "") SystemSounds.Hand.Play();

            else
            {
                switch (operation)
                {
                    case ("+"):
                        textBoxData.Text = (Convert.ToDouble(var1) + Convert.ToDouble(var2)).ToString();
                        var1 = textBoxData.Text;
                        break;
                    case ("-"):
                        textBoxData.Text = (Convert.ToDouble(var1) - Convert.ToDouble(var2)).ToString();
                        var1 = textBoxData.Text;
                        break;
                    case ("*"):
                        textBoxData.Text = (Convert.ToDouble(var1) * Convert.ToDouble(var2)).ToString();
                        var1 = textBoxData.Text;
                        break;
                    case (":"):
                        if (Convert.ToInt32(var2) == 0) textBoxData.Text = "Divide by 0!";
                        else
                        {
                            textBoxData.Text = (Convert.ToDouble(var1) / Convert.ToDouble(var2)).ToString();
                            var1 = textBoxData.Text;
                        }
                        break;

                }//end switch

                buttonEqualPressed = true;
                operationPressed = false;
                buttonClick = false;

            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (textBoxData.Text == "") SystemSounds.Hand.Play();
            else if (textBoxData.Text == "0") { textBoxData.Text = " "; Task.Delay(50).Wait(); textBoxData.Text = "0"; }
            else
            {
                if (textBoxData.Text == "") SystemSounds.Hand.Play();
                else textBoxData.Text = textBoxData.Text.Remove(textBoxData.Text.Length - 1);
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBoxData.Text = "0";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBoxData.Text = "0";
            labelMeanchwileWalue.Text = "";
            var1 = "";
            var2 = "";
            operation = ("");
            buttonEqualPressed = false;
            operationPressed = false;
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            buttonEqual.Focus();
            if (var1 == "") textBoxData.Text = "0";
            else
            {
                if (operation == "+" || operation == "-") textBoxData.Text = (Convert.ToDouble(var1) * Convert.ToDouble(textBoxData.Text) / 100).ToString();
                else textBoxData.Text = (Convert.ToDouble(textBoxData.Text) / 100).ToString();

                labelMeanchwileWalue.Text += $" {textBoxData.Text}";
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            buttonClick = true;
            if (buttonEqualPressed) buttonCE.PerformClick();
            if (textBoxData.Text == "0" || (operationPressed == true)) textBoxData.Text = "";
            if (labelMeanchwileWalue.Text == "0") labelMeanchwileWalue.Text = "";
            buttonEqual.Focus();

            if (labelMeanchwileWalue.Text != "")
            {
                operationPressed = false;
                Button b = (Button)sender;
                if (b.Text == "," && textBoxData.Text.Contains(",") == true) SystemSounds.Hand.Play();
                else
                {
                    textBoxData.Text += b.Text;

                }
            }
            else
            {
                operationPressed = false;
                Button b = (Button)sender;
                if (b.Text == "," && textBoxData.Text.Contains(",") == true) SystemSounds.Hand.Play();
                else
                {
                    textBoxData.Text += b.Text;
                }
            }
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show($"");
            //buttonEqual.Focus();
            //string tmp = Keys.Multiply.ToString();
            switch (e.KeyChar)
            {
                case (char)Keys.D0:
                    button0.PerformClick();
                    break;
                case (char)Keys.D1:
                    button1.PerformClick();
                    break;
                case (char)Keys.D2:
                    button2.PerformClick();
                    break;
                case (char)Keys.D3:
                    button3.PerformClick();
                    break;
                case (char)Keys.D4:
                    button4.PerformClick();
                    break;
                case (char)Keys.D5:
                    button5.PerformClick();
                    break;
                case (char)Keys.D6:
                    button6.PerformClick();
                    break;
                case (char)Keys.D7:
                    button7.PerformClick();
                    break;
                case (char)Keys.D8:
                    button8.PerformClick();
                    break;
                case (char)Keys.D9:
                    button9.PerformClick();
                    break;
                case '/':
                    buttonDivide.PerformClick();
                    break;
                case '*':
                    buttonMultiply.PerformClick();
                    break;
                case '-':
                    buttonMinus.PerformClick();
                    break;
                case '+':
                    buttonPlus.PerformClick();
                    break;
                case (char)13:
                    buttonEqual.PerformClick();
                    break;
                case ',':
                    buttonDot.PerformClick();
                    break;
                case (char)8:
                    buttonBack.PerformClick();
                    break;
                case (char)46:
                    buttonCE.PerformClick();
                    break;
                case (char)27:
                    buttonCE.PerformClick();
                    break;

                default:
                    break;

            }// end switch 
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (labelMeanchwileWalue.Text.Contains('=')) labelMeanchwileWalue.Text = "";

            if (labelMeanchwileWalue.Text != "" &&
                buttonClick == false && (
                labelMeanchwileWalue.Text[labelMeanchwileWalue.Text.Count() - 1] == '+' ||
                labelMeanchwileWalue.Text[labelMeanchwileWalue.Text.Count() - 1] == '-' ||
                labelMeanchwileWalue.Text[labelMeanchwileWalue.Text.Count() - 1] == ':' ||
                labelMeanchwileWalue.Text[labelMeanchwileWalue.Text.Count() - 1] == '*'))
            {
                labelMeanchwileWalue.Text = labelMeanchwileWalue.Text.Remove(labelMeanchwileWalue.Text.Count() - 1);
                operation = b.Text;
                labelMeanchwileWalue.Text += $"{operation}";
            }
            else if (!buttonEqualPressed)
            {
                if (var1 != "" && operation != "") // var1 ma nadaną wartość
                {
                    var2 = textBoxData.Text;
                    operationPressed = true;
                    buttonEqual_Click(sender, e);
                    operation = b.Text;
                    labelMeanchwileWalue.Text += $" {var2} {operation}";
                }
                else
                {
                    operation = b.Text;
                    var1 = textBoxData.Text;
                    operationPressed = true;
                    labelMeanchwileWalue.Text += $"{var1} {operation}";
                }
            }
            else
            {
                operation = b.Text;
                var1 = textBoxData.Text;
                labelMeanchwileWalue.Text += $" {var1} {operation}";
            }
            operationPressed = true;
            buttonClick = false;
            buttonEqualPressed = false;
        }
    }
}
