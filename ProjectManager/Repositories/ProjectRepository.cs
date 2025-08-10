using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
using ProjectManager.Data.Models;
using ProjectManager.Exceptions;

namespace ProjectManager.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagerDbContext _context;
        public ProjectRepository(ProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Project> Create(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task Delate(int id)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject is null)
            {
                throw new NotFoundException($"Project with id {id} does not exist. ");
            }

            _context.Remove(existingProject);
            await _context.SaveChangesAsync();

        }

        public async Task<Project> GetById(int id)
        {
            var project = await _context.Projects
                .Include(p => p.ProjectTasks)
                .FirstOrDefaultAsync(p =>p.Id == id);

            if (project is null)
            {
                throw new NotFoundException($"Project with id {id} does not exist. ");
            }
            return project;
        }

        public async Task<List<Project>> GettAll(string? searchText, string? sortBy, string? sortDirection)
        {
            var query = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(p =>p.Name.Contains(searchText) ||  p.Description.Contains(searchText));
            }

            // sortowanie
            if (!string.IsNullOrEmpty(sortDirection))
            {
                sortBy = string.IsNullOrEmpty(sortBy) ? "" : sortBy;

                switch (sortBy.ToLower())
                {
                    case "name":
                        query = sortDirection.ToLower() == "asc" ? query.OrderBy(t => t.Name) : query.OrderByDescending(t => t.Name);
                        break;
                    case "creratedate":
                        query = sortDirection.ToLower() == "Asc" ? query.OrderBy(t => t.CreatedDate) : query.OrderByDescending(t => t.CreatedDate);
                        break;
                    default:
                        query = sortDirection.ToLower() == "Asc" ? query.OrderBy(t => t.Id) : query.OrderByDescending(t => t.Id);
                        break;

                }
            }

            return await query
                .Include(p => p.ProjectTasks)
                .ToListAsync();

            //var projects  = await _context.Projects
            //    .Include(p =>p.ProjectTasks)
            //    .ToListAsync();
            //return projects;
        }

        public async Task<Project> Update(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id);
            if (project is null)
            {
                throw new NotFoundException($"Project with id {project.Id} does not exist. ");
            }

            _context.Entry(existingProject).CurrentValues.SetValues(project);
            _context.Entry(existingProject).Property(x => x.CreateDate).IsModified = false;
            //existingProject.Name = project.Name;
            //existingProject.Description = project.Description;

            await _context.SaveChangesAsync();
            return existingProject;
        }
    }
}
