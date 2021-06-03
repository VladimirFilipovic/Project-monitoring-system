using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.ProjectRepository
{
    public class EmployeeTaskRepository : Repository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
        void IEmployeeTaskRepository.Insert(EmployeeTask task)
        {
            Insert(task);
        }
    }
}
