using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models.Dto
{
    public class RequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? RequestDate { get; set; } //TODO: cannot be < present date (date when insert was made)   
        public bool? Accepted { get; set; }
        public bool? Deleted { get; set; }
        public string Specification { get; set; } //TODO SIZE RESTRICTION FLUENT API
        public Client? Client { get; set; }
        //public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
