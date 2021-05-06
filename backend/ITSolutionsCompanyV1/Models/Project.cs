using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Deadline { get; set; } //TODO: cannot be < present date (date when insert was made)
        public bool? Deleted { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<Task>? Tasks { get; set; }
        public List<Demo>? Demos { get; set; }
        public List<Documentation>? Documentation { get; set; }
        public List<EmployeeProject>? EmployeeProjects { get; set; }
        public Request Request { get; set; }

        public Project(Guid id, string name, DateTime deadline)
        {
            Id = id;
            Name = name;
            Deadline = deadline;
        }
    }
}
