using payments;
using System;

namespace ConsoleATM
{
    class ATM
    {
        public ATM()
        {
            Bank.wrongPinInputHandler += Notifier.WrongPinInput_Notify;
            Bank.notExistingCardNumberInputHandler += Notifier.NotExistingCardNumberInput_Notify;
            Bank.successfulPutOperationHandler += Notifier.SuccesssfulPut_Notify;
            Bank.unsuccessfulPutOperationHandler += Notifier.PutSumLessZero_Notify;
            Bank.successfulWithdrawOperationHandler += Notifier.SuccesssfulWithdraw_Notify;
            Bank.unsuccessfulWithdrawOperationHandler += Notifier.UnsuccesssfulWithdraw_Notify;
            Bank.balanceOutHandler += Notifier.BalanceRequstOut_Notify;
        }
        public void Menu()
        {
            string answer;
            string pin, number;
            while (true)
            {
                Console.WriteLine("Input card");
                Console.Write("Card number: ");
                number = Console.ReadLine();
                Console.Write("Pin: ");
                pin = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Put - 1");
                    Console.WriteLine("Withdraw - 2");
                    Console.WriteLine("Check balance - 3");
                    Console.WriteLine("Finish - 0");
                    answer = Console.ReadLine();
                    int sum;
                    if (answer.Equals("1"))
                    {
                        Console.WriteLine("Input sum");
                        sum = int.Parse(Console.ReadLine());
                        Bank.Put(number, pin, sum);
                    }
                    else if (answer.Equals("2"))
                    {
                        Console.WriteLine("Input sum");
                        sum = int.Parse(Console.ReadLine());
                        Bank.Withdraw(number, pin, sum);
                    }
                    else if (answer.Equals("3"))
                    {
                        Bank.CheckBalance(number, pin);
                    }
                    else if (answer.Equals("0"))
                        break;
                    else continue;
                }
                Console.WriteLine("Exit? Yes - 1, No - 2");
                answer = Console.ReadLine();
                if (answer.Equals("1"))
                    break;
                else
                    continue;
            }
        }
        private static class Notifier
        {
            public static void NotExistingCardNumberInput_Notify(string num)
            {
                Console.WriteLine(string.Format("Card {0} does not exist", num));
            }
            public static void WrongPinInput_Notify(BankAccount bankAccount, Card card)
            {
                Console.WriteLine(string.Format("Wrong pin for card {0}", card.Number)); ;
            }
            public static void SuccesssfulPut_Notify(Card card, BankAccount bankAccount, float sum)
            {
                Console.WriteLine(string.Format("Successfull put {0} to card {1}", sum, card.Number)); ;
            }
            public static void PutSumLessZero_Notify(Card card, BankAccount bankAccount, float sum)
            {
                Console.WriteLine(string.Format("Cannot fill card {0} for sum {1}", card.Number, sum)); ;
            }
            public static void SuccesssfulWithdraw_Notify(Card card, BankAccount bankAccount, float sum)
            {
                Console.WriteLine(string.Format("Successfully withdrawed {0} from card {1}", sum, card.Number)); ;
            }
            public static void UnsuccesssfulWithdraw_Notify(Card card, BankAccount bankAccount, float sum)
            {
                Console.WriteLine(string.Format("Cannot withdraw {1} from {0}", card.Number, sum)); ;
            }
            public static void BalanceRequstOut_Notify(Card card, BankAccount bankAccount)
            {
                Console.WriteLine(string.Format("Balance of card {0} is {1}", card.Number, bankAccount.Balance)); ;
            }
        }
    }
}
