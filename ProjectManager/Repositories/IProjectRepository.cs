using ProjectManager.Data.Models;

namespace ProjectManager.Repositories
{
    public interface IProjectRepository
    {
        public Task<Project> Create(Project project);
        public Task<Project> Update(Project project);
        public Task<List<Project>> GettAll();
        public Task<Project> GetById(int id);
        public Task Delate(int id);
    }
}
