using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Repositories.ApplicationUserRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.ApplicationUserService
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;
        //private IDocumentationRepository _documentationRepository; razmisljam da sve bude na frontu
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public ApplicationUserService (IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public List<Client> GetAllClients()
        {
           return _applicationUserRepository.GetClients();
        }

        public List<Employee> GetAllEmployees()
        {
            return _applicationUserRepository.GetEmployees();
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _applicationUserRepository.GetUsers();
        }

        public Employee GetEmployee(Guid id)
        {
            //u can also check here for projects and other stuff since logic is same as below
            return _applicationUserRepository.GetEmployeeById(id);
        }

        public void InsertEmployee(Employee employee)
        {
            //check here for documentation, tasks, projects and insert whole objects here
            IdentityResult result = _userManager.CreateAsync(employee, "E"+ employee.Email).Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(employee, "User").Wait();
            }
        }

        public void UpdateEmployee(Guid id, Employee employee)
        {
            _applicationUserRepository.UpdateUser(employee);
        }
    }
}
