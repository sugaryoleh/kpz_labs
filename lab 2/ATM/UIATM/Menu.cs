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
    public partial class Menu : Form
    {
        private string CardNumber;
        private string CardPin;
        MoneyManagementWondow mmw;
        public Menu(string CardNumber, string CardPin)
        {
            this.CardNumber = CardNumber;
            this.CardPin = CardPin;
            InitializeComponent();
            Notifier.init(label_message);
            Bank.balanceOutHandler += Notifier.BalanceRequstOut_Notify;
        }
        private static class Notifier
        {
            private static Label textBox;
            public static void init(Label tb)
            {
               textBox = tb;
            }
            public static void BalanceRequstOut_Notify(Card card, BankAccount bankAccount)
            {
                textBox.Text = string.Format("Balance of card {0} is {1}", card.Number, bankAccount.Balance);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_put_Click(object sender, EventArgs e)
        {
            mmw = new MoneyManagementWondow(this.CardNumber, this.CardPin, 1, this);
            mmw.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_checkBalance_Click(object sender, EventArgs e)
        {
            Bank.CheckBalance(CardNumber, CardPin);
        }

        private void button_withdraw_Click(object sender, EventArgs e)
        {
            mmw = new MoneyManagementWondow(this.CardNumber, this.CardPin, 2, this);
            mmw.Show();
            this.Hide();
        }
    }
}
