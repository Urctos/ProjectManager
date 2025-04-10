using AutoMapper;
using ProjectManager.Data.Models;
using ProjectManager.DTOs.ProjectDTO;

namespace ProjectManager.DTOs.ProjectTasksDTO
{
    public class ProjectTaskProfile : Profile
    {
        public ProjectTaskProfile()
        {
            CreateMap<ProjectTask, ProjectTaskDto>();
            CreateMap<CreateProjectTaskDto, ProjectTask>();
            CreateMap<UpdateProjectTaskDto, ProjectTask>();
        }
    }
}
