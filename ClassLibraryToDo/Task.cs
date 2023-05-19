using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryToDo
{
    public class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
