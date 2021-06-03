using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Models.Dto;
using ITSolutionsCompanyV1.Repositories.ProjectRepository;
using ITSolutionsCompanyV1.Service.ApplicationUserService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITSolutionsCompanyV1.Service.ProjectsService
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository taskRepository;
        private readonly IProjectsService projectsService;
        private readonly IApplicationUserService applicationUserService;
        private readonly IEmployeeTaskRepository employeeTaskRepository;

        public TasksService(ITasksRepository taskRepository, IProjectsService projectsService, IApplicationUserService applicationUserService, IEmployeeTaskRepository employeeTaskRepository)
        {
            this.taskRepository = taskRepository;
            this.projectsService = projectsService;
            this.applicationUserService = applicationUserService;
            this.employeeTaskRepository = employeeTaskRepository;
        }

        public void InsertTask(TaskCreationDto task)
        {
            Task insertTask = new Task(task.Id, task.Name, task.Description);
            insertTask.Deleted = false;
            insertTask.Completed = false;
            Project project = this.projectsService.GetById(task.ProjectId);
            insertTask.Project = project;
            taskRepository.InsertTask(insertTask);
            foreach(Guid id in task.Employees)
            {
               Employee employee = applicationUserService.GetEmployee(id);
                EmployeeTask employeeTask = new EmployeeTask();
                employeeTask.EmployeeId = employee.Id;
                employeeTask.Task = insertTask;
                employee.Deleted = false;
                employeeTaskRepository.Insert(employeeTask);

            }
        }
    }
}
