using ITSolutionsCompanyV1.Models.Dto;
using ITSolutionsCompanyV1.Service.ProjectsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Controllers
{
    [AllowAnonymous]
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase {


        private readonly ITasksService _tasksService;
        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        // POST: TasksController/Create
        [HttpPost]
        public ActionResult PostTask(TaskCreationDto task)
        {
            try
            {
                _tasksService.InsertTask(task);
                return Ok();

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
      
    
    }
}
