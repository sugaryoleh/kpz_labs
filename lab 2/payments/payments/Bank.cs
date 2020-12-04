using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace payments
{
    public static class Bank
    {
        private static int indexator;
        private static Dictionary<Card, BankAccount> bankAccounts;
        static Bank()
        {
            successfulPutOperationHandler += Notifier.SuccessfulPutOperationEmailNotify;
            unsuccessfulPutOperationHandler += Notifier.UnuccessfulPutOperationEmailNotify;
            wrongPinInputHandler += Notifier.WrongPinInputEmailNotify;
            successfulWithdrawOperationHandler += Notifier.SuccessfulWithdrawOperationEmailNotify;
            unsuccessfulWithdrawOperationHandler += Notifier.UnuccessfulWithdrawOperationEmailNotify;
            bankAccounts = new Dictionary<Card, BankAccount>();
            indexator = 0;
            CreateAccounts();
        }
        // temp filler
        private static void CreateAccounts()
        {
            AddAccount(new OwnerInfo("Oleh", "Sakharchuk", "0681374435", "olehs@real.us"));            
            AddAccount(new OwnerInfo("Tony", "Hernandez", "0502265769", "sugaryokeh@gmail.com"));            
        }
        public static void AddAccount(OwnerInfo ownerInfo)
        {
            indexator += 1;
            string num = "";
            for (int i = 0; i < 16 - indexator.ToString().Length; i++)
            {
                num +="0";
            }
            num += indexator.ToString();
            string pin = "";
            for (int i = 0; i < 4 - indexator.ToString().Length; i++)
            {
                pin += "0";
            }
            pin += indexator.ToString();
            Card card = new Card(num, pin);
            BankAccount bankAccount = new BankAccount(ownerInfo);
            bankAccounts.Add(card, bankAccount);
        }
        // handlers
        // authorization
        public delegate void NotExistingCardNumberInput(string cardNum);
        public static event NotExistingCardNumberInput notExistingCardNumberInputHandler;
        public delegate void WrongPinInput(BankAccount bankAccount, Card card);
        public static event WrongPinInput wrongPinInputHandler;
        // put
        public delegate void SuccessfulPutOperation(Card card, BankAccount bankAccount, float sum);
        public static event SuccessfulPutOperation successfulPutOperationHandler;
        public delegate void UnsuccessfulPutOperation(Card card, BankAccount bankAccount, float sum);
        public static event UnsuccessfulPutOperation unsuccessfulPutOperationHandler;
        // withdraw
        public delegate void SuccessfulWithdrawOperation(Card card, BankAccount bankAccount, float sum);
        public static event SuccessfulWithdrawOperation successfulWithdrawOperationHandler;
        public delegate void UnsuccessfulWithdrawOperation(Card card, BankAccount bankAccount, float sum);
        public static event UnsuccessfulWithdrawOperation unsuccessfulWithdrawOperationHandler;
        // balance request out
        public delegate void BalanceOut(Card card, BankAccount bankAccount);
        public static event BalanceOut balanceOutHandler;
        
        public static bool Authorize(string cardNumber, string pin)
        {
            foreach (Card _card in bankAccounts.Keys)
            {
                if (_card.Number.Equals(cardNumber))
                {
                    if (_card.Verify(pin))
                    {
                        return true;
                    }
                    else
                    {
                        //wrongPinInputHandler?.Invoke(bankAccounts[_card], _card);
                        return false;
                    }
                }
            }
            notExistingCardNumberInputHandler?.Invoke(cardNumber);
            return false;
        }
        private static bool Authorize(string cardNumber, string pin, out Card card)
        {
            foreach (Card _card in bankAccounts.Keys)
            {
                if (_card.Number.Equals(cardNumber))
                {
                    if(_card.Verify(pin))
                    {
                        card = _card;
                        return true;
                    }
                    else
                    {
                        wrongPinInputHandler?.Invoke(bankAccounts[_card], _card);
                        card = null;
                        return false;
                    }
                }
            }
            notExistingCardNumberInputHandler?.Invoke(cardNumber);
            card = null;
            return false;
        }
        public static void Put(string cardNumber, string pin, float sum)
        {
            Card card;
            if(Authorize(cardNumber, pin, out card))
            {
                bool payed = bankAccounts[card].Put(sum);
                if (payed)
                    successfulPutOperationHandler?.Invoke(card, bankAccounts[card], sum);
                else
                    unsuccessfulPutOperationHandler?.Invoke(card, bankAccounts[card], sum);
            }
        }
        public static void Withdraw(string cardNumber, string pin, float sum)
        {
            Card card;
            if (Authorize(cardNumber, pin, out card))
            {
                bool withdrawed = bankAccounts[card].Withdraw(sum);
                if (withdrawed)
                    successfulWithdrawOperationHandler?.Invoke(card, bankAccounts[card], sum);
                else
                    unsuccessfulWithdrawOperationHandler?.Invoke(card, bankAccounts[card], sum);
            }
        }
        public static void CheckBalance(string cardNumber, string pin)
        {
            Card card;
            if (Authorize(cardNumber, pin, out card))
            {
                balanceOutHandler?.Invoke(card, bankAccounts[card]);
            }
        }
        private static class Notifier
        {
            private static void EmailNotify(string to, string message)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sugaryoleh@gmail.com");
                mail.To.Add(to);
                mail.Subject = "Bank notification";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sugaryoleh", "Arkadiy18");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            // authorization
            public static void WrongPinInputEmailNotify(BankAccount bankAccount, Card card)
            {
                EmailNotify(bankAccount.OwnerInfo.Email, string.Format("{0} {1}, we detected unsuccessfull card authorization attempt to {2}", 
                     bankAccount.OwnerInfo.Name, bankAccount.OwnerInfo.Surname, card.Number));
            }
            // put
            public static void SuccessfulPutOperationEmailNotify(Card card, BankAccount bankAccount, float sum)
            {
                EmailNotify(bankAccount.OwnerInfo.Email, string.Format("Balance of card {0} is filled for {1}",
                     card.Number, sum));
            }
            public static void UnuccessfulPutOperationEmailNotify(Card card, BankAccount bankAccount, float sum)
            {
                EmailNotify(bankAccount.OwnerInfo.Email, string.Format("Unsuccessfull attempt to fill card {0} for {1}",
                     card.Number, sum));
            }
            // withdraw
            public static void SuccessfulWithdrawOperationEmailNotify(Card card, BankAccount bankAccount, float sum)
            {
                EmailNotify(bankAccount.OwnerInfo.Email, string.Format( "Withdrawed {1} from {0}",
                     card.Number, sum));
            }
            public static void UnuccessfulWithdrawOperationEmailNotify(Card card, BankAccount bankAccount, float sum)
            {
                EmailNotify(bankAccount.OwnerInfo.Email, string.Format("Unsuccessfull attempt to withdraw {1} from card {0}",
                     card.Number, sum));
            }
        }
    }
}
