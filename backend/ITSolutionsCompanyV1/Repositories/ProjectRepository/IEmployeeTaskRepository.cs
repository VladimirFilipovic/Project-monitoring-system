using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Repositories.ProjectRepository
{
    public interface IEmployeeTaskRepository
    {
        public void Insert(EmployeeTask task);
    }
}
