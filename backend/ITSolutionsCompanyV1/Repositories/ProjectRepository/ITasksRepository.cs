using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITSolutionsCompanyV1.Repositories.ProjectRepository
{
    public interface ITasksRepository
    {
        void InsertTask(Task task);

    }
}
