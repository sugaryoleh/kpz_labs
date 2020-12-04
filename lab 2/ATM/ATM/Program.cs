using payments;
using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleATM
{
    class Program
    {
        public static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.Menu();
            
        }
    }
}
