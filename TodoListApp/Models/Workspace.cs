using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public ApplicationUser Owner { get; set; }
        public List<ToDoList> ToDoLists { get; set; }
        public List<ApplicationUser> Users { get; set; }

    }
}
