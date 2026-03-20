using AutoMapper;
using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSubmittal_API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public ProjectsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return Ok(await _db.Projects.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }

            var project = await _db.Projects.FirstOrDefaultAsync(u => u.Id == id);

            if (project == null)
            {
                return NotFound($"Project with id {id} does not exist.");
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(ProjectCreateDTO projectDTO)
        {
            if (projectDTO == null)
            {
                return BadRequest("Project cannot be empty");
            }

            //Project project = new Project
            //{
            //    Name = projectDTO.Name,
            //    ProjectNumber = projectDTO.ProjectNumber,
            //    Address = projectDTO.Address
            //};
            Project project = _mapper.Map<Project>(projectDTO);

            await _db.AddAsync(project);
            await _db.SaveChangesAsync();

            return Ok(project);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, ProjectUpdateDTO projectDTO)
        {
            if (projectDTO == null)
            {
                return BadRequest("Project cannot be null");
            }
            if (id != projectDTO.Id)
            {
                return BadRequest($"Id does not match project id");
            }

            var project = await _db.Projects.FirstOrDefaultAsync(u => u.Id == id);
            if (project == null)
            {
                return NotFound($"Project with id of {id} does not exist.");
            }

            _mapper.Map(projectDTO, project);   // wont create tracking issue.. map dto -> project entity
            await _db.SaveChangesAsync();
            return Ok(projectDTO);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var project = _db.Projects.FirstOrDefault(u => u.Id == id);
            if (project == null)
            {
                return NotFound($"Id of {id} does not exist.");
            }

            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
