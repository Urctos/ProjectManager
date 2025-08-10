using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
using ProjectManager.Data.Models;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Tests
{
    public class ProjectRepositoryTests
    {
        private readonly ProjectManagerDbContext _context;
        private readonly ProjectRepository _repository;
        public ProjectRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ProjectManagerDbContext(options);
            SeedDatabase();

            _repository = new ProjectRepository(_context);
        }



        [Fact]
        public async Task GetAll_ShouldReturnAllProjects()
        {
            var projects = await _repository.GettAll(null, null, null);
            Assert.Equal(3, projects.Count);
        }

        private void SeedDatabase()
        {
            _context.Projects.AddRange(new List<Project>
            {
                new Project {Name = "Project A", Description = "Description A", CreateDate = new DateTime(2023,  1, 1)},
                new Project {Name = "Project B", Description = "Description B", CreateDate = new DateTime(2023,  1, 2)},
                new Project {Name = "Project C", Description = "Description C", CreateDate = new DateTime(2023,  1, 3)},
            });

            _context.SaveChanges();
        }
    }
}
