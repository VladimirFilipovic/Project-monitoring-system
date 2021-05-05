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
        public DateTime? StartDateOfContract { get; set; }
        public DateTime EndDateOfContract { get; set; } //TODO: this cannot be larger than start date
        public int NumberOfActiveProjects { get; set;} //TODO => 0
        public List<Request>? Requests { get; set; }
        public List<EmployeeTask>? EmployeeTasks { get; set; }
        public List<EmployeeProject>? EmployeeProjects { get; set; }
        public List<Documentation>? Documentation { get; set; }

        public Employee() : base() { }
        public Employee(decimal salary, DateTime? startDateOfContract, DateTime endDateOfContract,Guid id, string username, string email, string phoneNumber) : base(id, username, email, phoneNumber)
        {
            //TODO: check nulls for dates if null then dont asign -> dont throw error
            Salary = salary;
            StartDateOfContract = startDateOfContract;
            EndDateOfContract = endDateOfContract;
        }
    }
}
