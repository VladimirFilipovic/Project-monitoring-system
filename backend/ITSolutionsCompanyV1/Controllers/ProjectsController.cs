using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITSolutionsCompanyV1.Data;
using ITSolutionsCompanyV1.Models;
using ITSolutionsCompanyV1.Service.ProjectsService;
using ITSolutionsCompanyV1.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ITSolutionsCompanyV1.Controllers
{
    [AllowAnonymous]
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectsService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(ApplicationDbContext context, IProjectsService projectService, IMapper mapper)
        {
            _context = context;
            _projectService = projectService;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects(string? name)
        {
            List<Project> projects = new List<Project>();

            if(name != null) 
            {
                projects.Add(_projectService.GetByName(name));
                return projects;
            }
            return _projectService.GetAllProjects();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/rojects
        [HttpPost]
        public async Task<IActionResult> PostProject(ProjectDto project)
        {
            var string64 = project.Request.Specification;
            var string64fixed = string64.Substring(string64.LastIndexOf(',') + 1);
            byte[] newBytes = Convert.FromBase64String(string64fixed);

            Request request = _mapper.Map<Request>(project.Request);
            request.Specification = newBytes;

            Project projectEntity = _mapper.Map<Project>(project);
            projectEntity.Request = request;

            _projectService.InsertProject(projectEntity);
            return NoContent();
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        private bool ProjectExists(Guid id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
