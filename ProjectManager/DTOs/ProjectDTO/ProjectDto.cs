﻿using Microsoft.Identity.Client;

namespace ProjectManager.DTOs.ProjectDTO
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
    }
}
