using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using tasks_backend_api.Interfaces;
using tasks_backend_api.Models;
using tasks_backend_api.Repo;

namespace tasks_backend_api.Providers
{
    public class TaskProvider : ITaskProvider
    {
        private readonly TaskDbContext context;
        public TaskProvider(TaskDbContext context) 
        {
            this.context = context;
        }

        public async Task<(bool isSuccess, IEnumerable<TaskModel> results, string errorMessage)> GetTasksAsync()
        {
            try
            {
                seedData();

                var result = await context.Tasks.ToListAsync();
                
                if(result != null && result.Any())
                {
                    return (true, result, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        private void seedData()
        {
            context.Tasks.Add(new TaskModel { Id = 1, Title = "Task 1", Description = "This is Task 1" });
            context.Tasks.Add(new TaskModel { Id = 2, Title = "Task 2", Description = "This is Task 2" });
            context.Tasks.Add(new TaskModel { Id = 3, Title = "Task 3", Description = "This is Task 3" });
            context.SaveChanges();
        }
    }
}
