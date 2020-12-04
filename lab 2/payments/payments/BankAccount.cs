using System;

namespace payments
{
    public class BankAccount
    {
        private float balance;
        private OwnerInfo ownerInfo;
        public BankAccount(OwnerInfo ownerInfo)
        {
            this.balance = 0;
            this.ownerInfo = ownerInfo;
        }
        public OwnerInfo OwnerInfo
        {
            get { return ownerInfo; }
        }
        public bool Put(float val)
        {
            if (val > 0)
            {
                this.balance += val;
                return true;
            }
            return false;           
        }
        public bool Withdraw(float val)
        {
            if (val <= balance && val > 0)
            {
                balance -= val;
                return true;
            }
            return false;
        }
        public float Balance
        {
            get { return balance; }
        }
    }
}
