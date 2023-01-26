using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Business.Dtos;
using TasksAPI.Persistence.Data;

namespace TasksAPI.Business.Services
{
    public interface ITaskService
    {
        public List<TaskData> GetAllTasks(int userId,int limit,int skip);
        public bool UpdateTask(TaskDto data, int userId, int taskId);
        public bool DeleteTask(int taskId, int userId);
        public bool CreateTask(TaskDto data, int userId);
        public int BulkCreateTasks(IFormFile tasks, int userId);
    }
}
