﻿namespace MTKDotNetCore.ToDoListRestApi.ViewModels
{
    public class ToDoListViewModel
    {
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public int? CategoryId { get; set; }   
        public byte? PriorityLevel { get; set; }
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
