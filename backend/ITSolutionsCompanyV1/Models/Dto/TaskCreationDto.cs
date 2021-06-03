using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models.Dto
{
    public class TaskCreationDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public List<Guid>? Employees { get; set; }
        public Guid ProjectId { get; set; }

    }
}
