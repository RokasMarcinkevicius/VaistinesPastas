using System.ComponentModel.DataAnnotations;

namespace VaistinesPastas.Repository.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }

        public Client(string name, string address, string postCode)
        {
            Name = name;
            Address = address;
            PostCode = postCode;
        }
    }
}
