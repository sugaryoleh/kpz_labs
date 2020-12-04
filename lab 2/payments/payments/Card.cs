namespace payments
{
    public class Card
    {
        private string number;
        private string pin;
        public Card(string number, string pin)
        {
            this.number = number;
            this.pin = pin;
        }
        public string Number
        {
            get { return number;  }
        }
        public bool Verify(string pin)
        {
            if (pin == this.pin)
                return true;
            return false;
        }
    }
}