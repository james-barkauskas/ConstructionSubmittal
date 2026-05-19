using AutoMapper;
using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSubmittal_API.Controllers
{
    [Route("api/projects")] // this is the url to this controller.. 'localhost/api/projects' this is how requests hit our endpoints
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        // private, class-level variables that we can use throughout the controller, each method can access the '_service'..
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public ProjectsController(IMapper mapper, IProjectService projectService)  // our constructor gets 'service' injected..
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectReadDTO>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();   // retrieve the list of Projects so can map them to DTOs
            var projectsToReturn = _mapper.Map<IEnumerable<ProjectReadDTO>>(projects);
            return Ok(projectsToReturn);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectReadDTO>> GetProjectById([FromRoute] int id)
        {
            if (id <= 0) { return BadRequest("Invalid Id"); }   // instead of checking this, can use a routeConstraint: HttpGet("{id:int:min(1)}")

            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null) { return NotFound($"Project with id {id} does not exist."); }
            return Ok(_mapper.Map<ProjectReadDTO>(project));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectReadDTO>> CreateProject([FromBody] ProjectCreateDTO projectDTO)
        {
            if (projectDTO == null)
            {
                return BadRequest("Project cannot be empty");
            }

            Project project = _mapper.Map<Project>(projectDTO);

            var createdProject = await _projectService.CreateProjectAsync(project);
            if (createdProject == null)
            {
                return Conflict("A project with that job number already exists.");
            }

            var returnedProject = _mapper.Map<ProjectReadDTO>(createdProject);

            return CreatedAtAction(nameof(GetProjectById), new { id = returnedProject.Id }, returnedProject);   // best practice to return CreatedAtAction for Create method.. use OK for a get or update.. createdAtAction includes a location header..
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProjectReadDTO>> UpdateProject([FromRoute]int id, [FromBody]ProjectUpdateDTO projectDTO)
        {
            if (projectDTO == null) { return BadRequest("Project cannot be null"); }
            if (id != projectDTO.Id) { return BadRequest("Id does not match project id."); }    // this is more a 'legacy' pattern? maybe remove the Id property from updateDTO.. for better security..?

            var project = await _projectService.UpdateProjectAsync(id, _mapper.Map<Project>(projectDTO));
            if (project == null) { return NotFound(); }
            return Ok(_mapper.Map<ProjectReadDTO>(project));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)  // IActionResult better for delete b/c we return NoContent.. ActionResult<project> implies we will return a project, which is not the case for delete..
        {
            if (id <= 0) { return BadRequest("Enter valid id"); }
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result) { return NotFound($"Id of {id} does not exist."); }
            return NoContent();
        }
    }
}
