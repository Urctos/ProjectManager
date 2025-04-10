using ProjectManager.Data.Models;
using ProjectManager.DTOs.ProjectDTO;

namespace ProjectManager.Services
{
    public interface IProjectService
    {
        public Task<List<ProjectDto>> GetAll();
        public Task<ProjectDto> GetById(int id);
        public Task<ProjectDto> Create(CreateProjectDto createProjectDto);
        public Task<ProjectDto> Update(UpdateProjectDto updateProjectDto);
        public Task Delate(int id);



    }
}
