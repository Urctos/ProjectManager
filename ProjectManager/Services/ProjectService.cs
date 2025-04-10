using AutoMapper;
using ProjectManager.Data.Models;
using ProjectManager.DTOs.ProjectDTO;
using ProjectManager.Repositories;

namespace ProjectManager.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Create(CreateProjectDto createProjectDto)
        {
            var project = _mapper.Map<Project>(createProjectDto);
            project = await _projectRepository.Create(project);
            return _mapper.Map<ProjectDto>(project);
        }

        public Task Delate(int id)
        {
           return _projectRepository.Delate(id);
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            var projects = await _projectRepository.GettAll();
            var projectDtos = _mapper.Map<List<ProjectDto>>(projects);
            return (projectDtos);
        }

        public async Task<ProjectDto> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> Update(UpdateProjectDto updateProjectDto)
        {
            var project = _mapper.Map<Project>(updateProjectDto);
            project = await _projectRepository.Update(project);
            return _mapper.Map<ProjectDto>(project);
            
        }
    }
}
