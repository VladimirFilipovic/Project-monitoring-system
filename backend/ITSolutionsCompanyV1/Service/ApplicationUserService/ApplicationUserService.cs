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
        //private IDocumentService
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        public ApplicationUserService (IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Client DeleteClient(Guid id)
        {
           return _applicationUserRepository.DeleteClient(id);
        }

        public Employee DeleteEmployee(Guid id)
        {
           return _applicationUserRepository.DeleteEmployee(id);
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

        public Client GetClient(Guid id)
        {
            return _applicationUserRepository.GetClientById(id);
        }

        public Employee GetEmployee(Guid id)
        {
            //u can also check here for projects and other stuff since logic is same as below
            return _applicationUserRepository.GetEmployeeById(id);
        }

        public void InsertClient(Client client)
        {
            //check here for documentation, tasks, projects and insert whole objects here
            IdentityResult result = _userManager.CreateAsync(client, "C1" + client.Email).Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(client, "User").Wait();
            }
            else
            {
                throw new Exception();
            }
        }

        public void InsertEmployee(Employee employee)
        {
            //check here for documentation, tasks, projects and insert whole objects here
            IdentityResult result = _userManager.CreateAsync(employee, "E1"+ employee.Email).Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(employee, "User").Wait();
            }
            else
            {
                throw new Exception();
            }
        }

        public void UpdateClient(Guid id, Client client)
        {
            _applicationUserRepository.UpdateUser(client);
        }

        public void UpdateEmployee(Guid id, Employee employee)
        {
            _applicationUserRepository.UpdateUser(employee);
        }
         
        //TODO: Create methods for adding employee to project, reading docs,
        //assign to tasks or this should be in task,docum, and etc contollers
    }
}
