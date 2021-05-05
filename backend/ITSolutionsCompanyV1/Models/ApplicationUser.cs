using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Indicator whether the user account is active or disabled
        /// </summary>
        public bool AccountIsActive { get; set; } = true; //TODO: setter
        public bool Deleted { get; set; }

        //public byte[] UserImage { get; set; } 
        //TODO: add navigation property to claims
        public ApplicationUser() { }
        public ApplicationUser(string username, string email, string phoneNumber) : base(username)
        {
            //UserImage = userImage;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public ApplicationUser(Guid id, string username, string email, string phoneNumber) : base(username)
        {
            //UserImage = userImage;
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
