﻿using ProjectManager.DTOs.ProjectDTO;

namespace ProjectManager.DTOs.ProjectTasksDTO
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
    }
}
