namespace payments
{
    public class OwnerInfo
    {
        private string name;
        private string surname;
        private string phone;
        private string email;
        public OwnerInfo(string name, string surname, string phone, string email)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
        }
        public string Name 
        {
            get { return name; }
            set { name = value; } 
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}