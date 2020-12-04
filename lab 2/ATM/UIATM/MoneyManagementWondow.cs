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
    public partial class MoneyManagementWondow : Form
    {
        private string CardNumber;
        private string CardPin;
        public delegate void Operation(string CardNumber, string CardPin, float amt);
        Operation operationHandler;
        Menu menu;
        public MoneyManagementWondow(string CardNumber, string CardPin, int opcode, Menu menu)
        {
            InitializeComponent();
            this.CardNumber = CardNumber;
            this.CardPin = CardPin;
            this.menu = menu;
            Notifier.init(label_status);
            Bank.wrongPinInputHandler += Notifier.WrongPinInput_Notify;
            Bank.notExistingCardNumberInputHandler += Notifier.NotExistingCardNumberInput_Notify;
            Bank.successfulPutOperationHandler += Notifier.SuccesssfulPut_Notify;
            Bank.unsuccessfulPutOperationHandler += Notifier.PutSumLessZero_Notify;
            Bank.successfulWithdrawOperationHandler += Notifier.SuccesssfulWithdraw_Notify;
            Bank.unsuccessfulWithdrawOperationHandler += Notifier.UnsuccesssfulWithdraw_Notify;
            Bank.balanceOutHandler += Notifier.BalanceRequstOut_Notify;
            operationHandler = null;
            if (opcode == 1)
            {
                operationHandler = Bank.Put;
            }
            else if (opcode == 2)
                operationHandler += Bank.Withdraw;
        }
        private static class Notifier
        {
            private static Label textBox;
            public static void init(Label tb)
            {
                textBox = tb;
            }
            public static void NotExistingCardNumberInput_Notify(string num)
            {
                textBox.Text = string.Format("Card {0} does not exist", num);
            }
            public static void WrongPinInput_Notify(BankAccount bankAccount, Card card)
            {
                textBox.Text = string.Format("Wrong pin for card {0}", card.Number);
            }
            public static void SuccesssfulPut_Notify(Card card, BankAccount bankAccount, float sum)
            {
                textBox.Text = string.Format("Successfull put {0} to card {1}", sum, card.Number);
            }
            public static void PutSumLessZero_Notify(Card card, BankAccount bankAccount, float sum)
            {
                textBox.Text = string.Format("Cannot fill card {0} for sum {1}", card.Number, sum);
            }
            public static void SuccesssfulWithdraw_Notify(Card card, BankAccount bankAccount, float sum)
            {
                textBox.Text = string.Format("Successfully withdrawed {0} from card {1}", sum, card.Number);
            }
            public static void UnsuccesssfulWithdraw_Notify(Card card, BankAccount bankAccount, float sum)
            {
                textBox.Text = string.Format("Cannot withdraw {1} from {0}", card.Number, sum);
            }
            public static void BalanceRequstOut_Notify(Card card, BankAccount bankAccount)
            {
                textBox.Text = string.Format("Balance of card {0} is {1}", card.Number, bankAccount.Balance);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text = "1";  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "5";        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text += "0";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_AmountValue.Text = "";
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            operationHandler?.Invoke(CardNumber, CardPin, float.Parse(this.textBox_AmountValue.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();  
        }
    }
}
