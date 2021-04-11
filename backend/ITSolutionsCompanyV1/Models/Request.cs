using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public DateTime? DateSent { get; set; } //TODO: cannot be < present date (date when insert was made)   
        public bool? Accepted { get; set; }
        public byte[] Specification { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Request(Guid id, string name, DateTime? dateSent, bool? accepted, byte[] specification)
        {
            Id = id;
            Name = name;
            DateSent = dateSent;
            Accepted = accepted;
            Specification = specification;
        }
    }
}
