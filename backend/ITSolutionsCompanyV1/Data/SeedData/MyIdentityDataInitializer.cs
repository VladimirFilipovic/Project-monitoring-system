using ITSolutionsCompanyV1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedUsersAndRoles(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            Guid adminGuid = new Guid ("e9a2ee58-8838-4ff6-bb78-23f57373a699");
            Guid employee1Guid = new Guid ("e06ba72a-3469-4eb3-82c6-606d5e57a807");
            Guid employee2Guid = new Guid ("b16ac5fc-61ab-4509-ab2d-b4b2ed2897b9");
            Guid client1Guid = new Guid ("a22752d6-1ab6-4f16-90a6-8845241a936c");
            Guid client2Guid = new Guid ("1d2caad3-b0fd-4e47-8eeb-ce335f7b1259");

            if (userManager.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser adminUser = new ApplicationUser(adminGuid, "admin", "admin@gmail.com", "+38105056665");

                IdentityResult result = userManager.CreateAsync(adminUser, "Admin101.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Administrator").Wait();
                }
            }

            if (userManager.FindByNameAsync("client").Result == null)
            {
                Client client1 = new Client("client1", "00000001", client1Guid, "client", "client1@gmail.com", "+3811025543");

                IdentityResult result = userManager.CreateAsync(client1, "Client101.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(client1, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("client2").Result == null)
            {
                Client client2 = new Client("client2", "00000002", client2Guid, "client2", "client2@gmail.com", "+3811025544");

                IdentityResult result = userManager.CreateAsync(client2, "Client202.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(client2, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("employee1").Result == null)
            {
                Employee employee1 = new Employee(120000, null, new DateTime(2022, 6, 6), employee1Guid, "employee1", "employee1@gmail.com", "+381691024466");

                IdentityResult result = userManager.CreateAsync(employee1, "Employee101.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee1, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("employee2").Result == null)
            {
                Employee employee2 = new Employee(120000, null, new DateTime(2022, 6, 6), employee2Guid, "employee2", "employee2@gmail.com", "+381691024466");

                IdentityResult result = userManager.CreateAsync(employee2, "Employee202.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(employee2, "User").Wait();
                }
            }

        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                ApplicationRole adminRole = new ApplicationRole("Role that enables root level privileges", "Administrator");
                IdentityResult roleResult = roleManager.CreateAsync(adminRole).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                ApplicationRole regularUserRole = new ApplicationRole("Role that enables basic level privileges", "User");
                IdentityResult roleResult = roleManager.CreateAsync(regularUserRole).Result;
            }
        }
    }
}
