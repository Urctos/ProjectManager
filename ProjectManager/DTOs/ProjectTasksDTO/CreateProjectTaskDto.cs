﻿namespace ProjectManager.DTOs.ProjectTasksDTO
{
    public class CreateProjectTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
    }
}
