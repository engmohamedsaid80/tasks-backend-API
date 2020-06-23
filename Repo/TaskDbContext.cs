using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasks_backend_api.Models;

namespace tasks_backend_api.Repo
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public TaskDbContext(DbContextOptions options) : base(options) { }
    }
}
