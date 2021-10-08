using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListApp.Models;

namespace TodoListApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
