using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Client : ApplicationUser
    {
        public string CompanyName { get; set; }
        public string Pib { get; set; } //TODO: range 10000001-99999999
        public List<Request>? Requests { get; set; }
        public List<Payment>? Payment { get; set; }
        public Client() : base() { }
        public Client(string companyName, string pib, Guid id, string username, string email, string phoneNumber) : base(id, username, email, phoneNumber)
        {
            CompanyName = companyName;
            Pib = pib;
        }
    }
}
