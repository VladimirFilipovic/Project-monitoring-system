using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Client : ApplicationUser
    {
        [MaxLength(500)]
        public string CompanyName { get; set; }
        [MaxLength(8)]
        public string Pib { get; set; } //TODO: range 10000001-99999999
        
        public List<Request>? Requests { get; set; }

        public Client(string companyName, string pib, byte[] userImage) : base(userImage)
        {
            CompanyName = companyName;
            Pib = pib;
        }
    }
}
