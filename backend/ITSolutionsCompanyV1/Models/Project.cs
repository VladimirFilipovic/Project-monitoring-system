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
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime Deadline { get; set; } //TODO: cannot be < present date (date when insert was made)
        public Project(Guid id, string name, DateTime deadline)
        {
            Id = id;
            Name = name;
            Deadline = deadline;
        }
    }
}
