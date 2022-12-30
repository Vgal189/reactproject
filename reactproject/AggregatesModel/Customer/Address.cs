namespace reactproject.AggregatesModel.Customer
{
    public class Address
    {
        public Address(string line1, string line2, string city, string state, string zipCode)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
}
