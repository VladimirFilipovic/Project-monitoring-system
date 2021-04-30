using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class EmployeeProject
    {
        public string RoleOnProject { get; set; } //TODO check whether the role is in ProjectRoles
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public bool Deleted { get; set; }
    }
}
