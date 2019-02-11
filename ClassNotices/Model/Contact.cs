namespace ClassNotices.Model
{
    class Contact
    {
        public Contact()
        {

        }
        public Contact(string number)
        {
            Number = number;
        }
        public string Number { get; set; }
    }
}