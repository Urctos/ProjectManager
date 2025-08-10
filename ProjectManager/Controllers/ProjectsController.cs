using AutoMapper.Configuration.Annotations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Data.Models;
using ProjectManager.DTOs.ProjectDTO;
using ProjectManager.Exceptions;
using ProjectManager.Services;

namespace ProjectManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IValidator<CreateProjectDto> _createProjectDtoValidator;
        private readonly IValidator<UpdateProjectDto> _updateProjectDtoValidator;
        public ProjectsController(
            IProjectService projectService,
            IValidator<UpdateProjectDto> updateProjectDtoValidator,
            IValidator<CreateProjectDto> createProjectDtoValidator)
        {
            _projectService = projectService;
            _createProjectDtoValidator = createProjectDtoValidator;
            _updateProjectDtoValidator = updateProjectDtoValidator;
        }


        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Create([FromBody] CreateProjectDto createProjectDto)
        {
            _createProjectDtoValidator.ValidateAndThrow(createProjectDto);
            var projectDto = await _projectService.Create(createProjectDto);
            return Ok(projectDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetAll(
                        [FromQuery] string? searchText,
                        [FromQuery] string? sortBy,
                        [FromQuery] string? sortDirection
                        )
        {
            var projects = await _projectService.GetAll(searchText, sortBy, sortDirection);
            return Ok(projects);
            //var projectDto = await _projectService.GetAll();
            //return Ok(projectDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProjectDto>>> GetAById([FromRoute] int id)
        {
                var project = await _projectService.GetById(id);
                return Ok(project);
        }

        [HttpPut]
        public async Task<ActionResult<ProjectDto>> Update([FromBody] UpdateProjectDto updateProjectDto)
        {
            _updateProjectDtoValidator.ValidateAndThrow(updateProjectDto);
            var projectDto = await _projectService.Update(updateProjectDto);
                return Ok(projectDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delate([FromRoute] int id)
        {
                await _projectService.Delate(id);
                return Ok();
        }
    }
}
