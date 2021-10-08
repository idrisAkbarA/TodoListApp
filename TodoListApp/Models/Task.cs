using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsDone { get; set; } = false;
        public List<Task> Subtasks{ get; set; }
        public List<ApplicationUser> Workers { get; set; }
        public DateTime DueDate { get; set; }

    }
}
