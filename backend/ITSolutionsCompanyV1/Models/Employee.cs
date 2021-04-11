using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Employee : ApplicationUser
    {   
        public decimal Salary { get; set; }  //TODO: this cannot be below < 0
        public DateTime StartDateOfContract { get; set; }
        public DateTime EndDateOfContract { get; set; } //TODO: this cannot be larger than start date
        
        public List<Request>? Requests { get; set; }
        public List<Task>? Tasks { get; set; }

        public Employee(decimal salary, DateTime startDateOfContract, DateTime endDateOfContract, byte[] userImage) : base(userImage)
        {
            Salary = salary;
            StartDateOfContract = startDateOfContract;
            EndDateOfContract = endDateOfContract;
        }
    }
}
