using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.DTOs.ProjectDTO;
using ProjectManager.DTOs.ProjectTasksDTO;
using ProjectManager.Services;
using System.Data;

namespace ProjectManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTasksController : ControllerBase
    {
        private readonly IProjectTaskService _projectTasksService;
        private readonly IValidator<CreateProjectTaskDto> _createProjectTaskDtoValidator;
        private readonly IValidator<UpdateProjectTaskDto> _updateProjectTaskDtoValidator;

        public ProjectTasksController(IProjectTaskService projectTaskService,
               IValidator<CreateProjectTaskDto> createProjectTaskDtoValidator,
               IValidator<UpdateProjectTaskDto> updateProjectTaskDtoValidator)
        {
            _projectTasksService = projectTaskService;
            _createProjectTaskDtoValidator = createProjectTaskDtoValidator;
            _updateProjectTaskDtoValidator = updateProjectTaskDtoValidator;         
        }
        [HttpGet]
        public async Task<ActionResult<List<ProjectTaskDto>>> GetAll(
            [FromQuery] string? searchText,
            [FromQuery] DateTime? dueDate,
            [FromQuery] bool? isCompleted
            )
        { 
            var projectTasks = await _projectTasksService.GetAll(searchText, dueDate, isCompleted );
            return Ok(projectTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectTaskDto>> GetById([FromRoute] int id)
        {
            var projectTasks = await _projectTasksService.GetById(id);
            return Ok(projectTasks);
        }

        [HttpGet("byProject/{projectId}")]
        public async Task<ActionResult<List<ProjectTaskDto>>> GetByProjectId([FromRoute]int projectId)
        {
            var projectTasks = await _projectTasksService.GetByProjectId(projectId);
            return Ok(projectTasks);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectTaskDto>> Add(CreateProjectTaskDto createProjectTaskDto)
        {
            _createProjectTaskDtoValidator.ValidateAndThrow(createProjectTaskDto);
            var projectTask = await _projectTasksService.Add(createProjectTaskDto);
            return Ok(projectTask);
        }

        [HttpPut]
        public async Task<ActionResult<ProjectTaskDto>> Update(UpdateProjectTaskDto updateProjectTaskDto)
        {
            _updateProjectTaskDtoValidator.ValidateAndThrow(updateProjectTaskDto);
            var   projectTasks = await _projectTasksService.Update(updateProjectTaskDto);
            return Ok(projectTasks);
            
        }
        [HttpDelete]
        public async Task<ActionResult> Delate(int id)
        {
            await _projectTasksService.Delate(id);
            return NoContent();
        }
        


    }
}
