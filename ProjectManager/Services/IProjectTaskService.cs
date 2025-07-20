using ProjectManager.Data.Models;
using ProjectManager.DTOs.ProjectTasksDTO;
using System.Data;

namespace ProjectManager.Services
{
    public interface IProjectTaskService
    {
        public Task<List<ProjectTaskDto>> GetAll(string? searchText,DateTime? dueDate, bool? isCompleted);
        public Task<ProjectTaskDto?> GetById(int id);
        public Task<List<ProjectTaskDto>> GetByProjectId(int projectId);
        public Task<ProjectTaskDto> Add(CreateProjectTaskDto createProjectTaskDto);
        public Task<ProjectTaskDto> Update(UpdateProjectTaskDto updateProjectTaskDto);
        public Task Delate(int id);
    }
}
