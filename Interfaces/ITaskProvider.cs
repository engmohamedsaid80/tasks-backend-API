using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasks_backend_api.Models;

namespace tasks_backend_api.Interfaces
{
    public interface ITaskProvider
    {
        Task<(bool isSuccess, IEnumerable<TaskModel> results, string errorMessage)> GetTasksAsync();
    }
}
