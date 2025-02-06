using System.Text;

namespace CapgAppLibrary
{
    public class Customer
    {

        public string CustomerId { get; set; } = "";
        public string CompanyName { get; set; } = ""; 
        public string ContactName { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("****** Customer Details ******\n")
                .Append("\tCustomer Id: ").AppendLine(CustomerId)
                .Append("\tCompany Name: ").AppendLine(CompanyName)
                .Append("\tContact Name: ").AppendLine(ContactName)
                .Append("\tCity: ").AppendLine(City)
                .Append("\tCountry: ").AppendLine(Country);
            return sb.ToString();
        }
    }
}
