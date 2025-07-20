using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
using ProjectManager.Data.Models;
using ProjectManager.Exceptions;
using System.Data;

namespace ProjectManager.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ProjectManagerDbContext _context;
        public ProjectTaskRepository(ProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectTask> Add(ProjectTask projectTask)
        {
            await _context.ProjectTasks.AddAsync(projectTask);
            await _context.SaveChangesAsync();
            return projectTask;

        }

        public async Task Delate(int id)
        {
            var existingProjectTask = await _context.ProjectTasks.FindAsync(id);
            if (existingProjectTask is null)
            {
                throw new DirectoryNotFoundException($"ProjectTask with id {id} not found ");
            }
            _context.ProjectTasks.Remove(existingProjectTask);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProjectTask>> GettAll(string? searchText,
             DateTime? dueDate, bool? isCompleted)
        {
            var query = _context.ProjectTasks.AsQueryable();

            // Wyszukiwanie po tytule lub opisie 

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(pt => pt.Title.Contains(searchText.ToLower()) || pt.Description.Contains(searchText.ToLower()));
            }


            // filtrowanie po dacie 
            if (dueDate.HasValue)
            {
                query = query.Where(pt => pt.DueDate <= dueDate);
            }

            // po statusie ukończenia
            if (isCompleted.HasValue)
            {
                query = query.Where(pt => pt.IsCompleted == isCompleted);
            }

            return await query
                .Include(x => x.Project)
                .ToListAsync();
        }

        public async Task<ProjectTask?> GetById(int id)
        {
            var prjectTask = await _context.ProjectTasks
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (prjectTask is null)
            {
                throw new NotFoundException($"Proiject with id {id} not found");
            }
            return prjectTask;
        }

        public async Task<List<ProjectTask>> GetByProjectId(int projectId)
        {
            var prjectExist = await _context.Projects
                .AnyAsync(p => p.Id == projectId);

            if (!prjectExist)
            {
                throw new NotFoundException($"Proiject with id {projectId} not found");
            }
            return await _context.ProjectTasks
                .Where(pt => pt.ProjectId == projectId)
                .ToListAsync();
        }


        public async Task<ProjectTask> Update(ProjectTask projectTask)
        {
        var existingProjectTasks = await _context.ProjectTasks.FindAsync(projectTask.Id);

        if(existingProjectTasks is null)
        {
            throw new NotFoundException($"ProijectTasks with id {projectTask.Id} not found");
        }
        existingProjectTasks.Title = projectTask.Title;
        existingProjectTasks.Description = projectTask.Description;
        existingProjectTasks.DueDate = projectTask.DueDate;
        existingProjectTasks.IsCompleted = projectTask.IsCompleted;
        await _context.SaveChangesAsync();
        return existingProjectTasks;
        } 
    }
}
