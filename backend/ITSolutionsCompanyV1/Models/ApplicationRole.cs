using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        /// <summary>
        /// Descripton of a given role
        /// </summary>
        public string Description { get; set; }
        public bool Deleted { get; set; }


        private ApplicationRole() : base()
        {
            Description = "no description";
        }

        public ApplicationRole(string description, string roleName) : base(roleName)
        {
            Description = description;
        }

        public ApplicationRole(Guid id, string description, string roleName) : base(roleName)
        {
            Id = id;
            Description = description;
        }
    }
}
