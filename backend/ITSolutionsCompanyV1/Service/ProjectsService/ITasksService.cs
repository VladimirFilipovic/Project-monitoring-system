using ITSolutionsCompanyV1.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Service.ProjectsService
{
    public interface ITasksService
    {
        public void InsertTask(TaskCreationDto task);

    }
}
