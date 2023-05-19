using System;
using System.Collections.Generic;

namespace ClassLibraryToDo
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        // public int NextUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
