using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public List<EmployeeTask>? EmployeeTasks { get; set; }
        public Project Project { get; set; }

        public Task(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Task(Guid id, string name, bool completed, string description) : this(id, name, description)
        {
            Completed = completed;
        }
    }
}
