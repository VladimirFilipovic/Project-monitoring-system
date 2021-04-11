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
        public bool AccountIsActive { get; set; } = true;
        public byte[] UserImage { get; set; }
        public ApplicationUser(byte[] userImage) : base()
        {
            UserImage = userImage;
        }
    }
}
