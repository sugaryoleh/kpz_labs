using payments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIATM
{
    public partial class Authorization : Form
    {
        public TextBox activeTextBox;
        public Authorization()
        {
            InitializeComponent();
            activeTextBox = textBox_CardNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(9);
        }
        private void button0_Click(object sender, EventArgs e)
        {
            sendKeyToActiveTextBox(0);
        }
        private void textBox_CardNumber_Clicked(object sender, EventArgs e)
        {
            activeTextBox = textBox_CardNumber;
        }
        private void textBox_CardPin_Clicked(object sender, EventArgs e)
        {
            activeTextBox = textBox_CardPin;
        }
        private void sendKeyToActiveTextBox(int v)
        {
            activeTextBox.Text += v.ToString();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            activeTextBox.Text = "";
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            string CardNumber, CardPin;
            if (Authorize(out CardNumber, out CardPin))
             {
                Menu menu = new Menu(CardNumber, CardPin);
                menu.Show();
                this.Hide();
            }

        }

        private bool Authorize(out string CardNumber, out string CardPin)
        {
            CardNumber = null;
            CardPin = null;
            if (textBox_CardNumber.Text.Length == 16)
                CardNumber = textBox_CardNumber.Text;
            else
                return false;
            if (textBox_CardPin.Text.Length == 4)
                CardPin = textBox_CardPin.Text;
            else 
                return false;
            if (Bank.Authorize(CardNumber, CardPin))
                return true;
            else
                return false;
        }
    }
}
