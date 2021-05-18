using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class EmployeeTask
    {
        //TODO: check whether the keys are okay
        public Guid EmployeeId { get; set; }
        public  Employee Employee { get; set; }
        public Guid TaskId { get; set; }
        public  Task Task { get; set; }
        public bool Deleted { get; set; }
    }
}
