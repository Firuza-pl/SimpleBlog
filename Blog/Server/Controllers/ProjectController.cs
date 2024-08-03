using AutoMapper;
using Blog.Application.Commands.ProjectCommands;
using Blog.Application.Exceptions;
using Blog.Application.Queries.GetPaginatedProject;
using Blog.Common.Constants;
using Blog.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProjectController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ProjectController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

#if !DEBUG
        [Authorize] 
#endif
        [HttpGet("GetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectAsync()
        {
            var projectDTO = await _mediator.Send(new GetPaginatedProjectQuery());
            return Ok(projectDTO);
        }

        [HttpGet("EditBy/{projectId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProjectDTO>> GetProjectIdAsync(Guid projectId)
        {
            var projectDTO = await _mediator.Send(new GetPaginatedProjectIdQuery(projectId));

            if (projectDTO == null)
            {
                return NotFound();
            }

            return Ok(projectDTO);
        }

        [HttpPost("CreateProject")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProject(CreateProjectDTO projectDTO)
        {
            var projectCommand = new CreateProjectCommand(Guid.NewGuid(), projectDTO.Title, projectDTO.Description);
            try
            {
                await _mediator.Send(projectCommand);
            }

            catch (NotFoundException)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetProjectIdAsync), ControllerConstants.Project,
                new { ProjectId = projectCommand.ProjectId }, projectCommand);
        }


        [HttpPut("UpdateBy/{projectId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateProject(Guid projectId, UpdateProjectDTO projectDTO)
        {
            if (projectId != projectDTO.ProjectId)
            {
                return BadRequest();
            }

            var projectCommand = new UpdateProjectCommand(projectDTO.ProjectId, projectDTO.Title, projectDTO.Description);

            try
            {
                await _mediator.Send(projectCommand);
            }

            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{projectId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProject(Guid projectId)
        {
            var deleteCommand = new DeleteProjectCommand(projectId);

            try
            {
                await _mediator.Send(deleteCommand);
            }

            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}


