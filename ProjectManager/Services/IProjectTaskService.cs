using ProjectManager.Data.Models;
using ProjectManager.DTOs.ProjectTasksDTO;

namespace ProjectManager.Services
{
    public interface IProjectTaskService
    {
        public Task<List<ProjectTaskDto>> GetAll();
        public Task<ProjectTaskDto?> GetById(int id);
        public Task<List<ProjectTaskDto>> GetByProjectId(int projectId);
        public Task<ProjectTaskDto> Add(CreateProjectTaskDto createProjectTaskDto);
        public Task<ProjectTaskDto> Update(UpdateProjectTaskDto updateProjectTaskDto);
        public Task Delate(int id);
    }
}
