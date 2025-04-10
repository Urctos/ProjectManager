using ProjectManager.Data.Models;

namespace ProjectManager.Repositories
{
    public interface IProjectTaskRepository
    {
        public Task<List<ProjectTask>> GettAll();
        public Task<ProjectTask?> GetById(int id);
        public Task<List<ProjectTask>> GetByProjectId(int projectId);
        public Task<ProjectTask> Add(ProjectTask projectTask);
        public Task<ProjectTask> Update(ProjectTask projectTask);
        public Task Delate(int id);
    }
}
