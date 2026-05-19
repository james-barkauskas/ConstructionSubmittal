using AutoMapper;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionSubmittal_API.Controllers
{
    [Route("api/submittals")]
    [ApiController]
    public class SubmittalsController : ControllerBase
    {
        private readonly ISubmittalService _submittalService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public SubmittalsController(ISubmittalService submittalService, IProjectService projectService, IMapper mapper)
        {
            _submittalService = submittalService;
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet("project/{projectId}/submittals")] // more descriptive route
        public async Task<ActionResult<IEnumerable<SubmittalReadDTO>>> GetSubmittalsByProject([FromRoute] int projectId)
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            if (project == null) { return NotFound($"Project with id {projectId} does not exist."); }

            var submittals = await _submittalService.GetAllSubimttalsByProjectAsync(projectId);
            return Ok(_mapper.Map<IEnumerable<SubmittalReadDTO>>(submittals));

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SubmittalReadDTO>> GetSubmittalById([FromRoute] int id)
        {
            if (id <= 0) { return BadRequest("Enter valid submittal id."); }
            var submittal = await _submittalService.GetSubmittalByIdAsync(id);
            if (submittal == null) { return NotFound($"Submittal with id of {id} does not exist."); }
            return Ok(_mapper.Map<SubmittalReadDTO>(submittal));
        }

        [HttpPost]
        public async Task<ActionResult<SubmittalReadDTO>> CreateSubmittal([FromBody]SubmittalCreateDTO submittalDto)
        {
            // consider sending back more specific error messages..
            if (submittalDto == null) { return BadRequest("Submittal object should not be empty."); }
            var submittalCreated = await _submittalService.CreateSubmittalAsync(_mapper.Map<Submittal>(submittalDto));
            if (submittalCreated == null) { return BadRequest("Invalid submittal object."); }

            var submittalToReturn = _mapper.Map<SubmittalReadDTO>(submittalCreated);
            return CreatedAtAction(nameof(GetSubmittalById), new { id = submittalToReturn.Id }, submittalToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SubmittalReadDTO>> UpdateSubmittal([FromRoute] int id, [FromBody] SubmittalUpdateDTO submittalDto)
        {
            if (submittalDto == null || id != submittalDto.Id) { return BadRequest("Invalid data"); }
            var submittalFromService = await _submittalService.UpdateSubmittalAsync(id, submittalDto);  // pass in Dto instead..
            if (submittalFromService ==  null) { return NotFound($"Submittal does not exist with id of {id}"); }

            var submittalToReturn = _mapper.Map<SubmittalReadDTO>(submittalFromService);
            return Ok(submittalToReturn);
            // can also return NoContent for updates..
            // consider adding custom responses to give different message depending on error from the service..
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubmittal([FromRoute]int id)
        {
            if (id <= 0) { return BadRequest("Enter valid Id."); }
            var success = await _submittalService.DeleteSubmittalAsync(id);
            if (!success) { return NotFound($"Id of {id} does not exist."); }
            return NoContent();
        }
    }
}
