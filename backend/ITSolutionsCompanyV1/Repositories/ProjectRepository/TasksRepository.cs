using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITSolutionsCompanyV1.Repositories.ProjectRepository
{
    public class TasksRepository : Repository<Task>, ITasksRepository
    {

        public TasksRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
        public void InsertTask(Task task)
        {
            Insert(task);
        }
    }
}
