using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Business.Dtos;
using TasksAPI.Business.Extensions;
using TasksAPI.Persistence.Data;
using TasksAPI.Persistence.Migrations;
using TasksAPI.Persistence.Repsitories;

namespace TasksAPI.Business.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ILogger<TaskService> _logger;
        private readonly ITaskRepository _taskRepository;
        public TaskService(ILogger<TaskService> logger, ITaskRepository taskRepository) {
            _logger = logger;
            _taskRepository = taskRepository;
        } 
        public int BulkCreateTasks(IFormFile file ,int userId)
        {
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Files");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filepath = Path.Combine(path, filename);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
            }
            if (fileextension == ".csv")
            {
                var data = new List<TaskData>();
                using (var reader = new StreamReader(filepath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        var records = csv.GetRecords<TaskDto>();
                        foreach (var record in records)
                        {

                            if (string.IsNullOrWhiteSpace(record.Title))
                            {
                                break;
                            }
                            TaskData taskData = new TaskData();

                            taskData.UserId = userId;
                            taskData.Title = record.Title;
                            taskData.StartDate = record.StartDate;
                            taskData.EndDate = record.EndDate;
                            data.Add(taskData);
                        }
                    }
                    catch
                    {
                        ExceptionManager.ThrowInvalidDto("wrong file structure");
                    }
                    return _taskRepository.BulkCreate(data).Result;
                }
            }
            ExceptionManager.ThrowInvalidDto("wrong file type");
            return 0;
        }

        public bool CreateTask(TaskDto data ,int userId)
        {
            if (data.EndDate < data.StartDate)
                ExceptionManager.ThrowInvalidDto("end date is less than start date");
            var taskData = new TaskData() { Title= data.Title, EndDate = data.EndDate,StartDate = data.StartDate, UserId = userId};
            var check = _taskRepository.GetByPeriod(taskData.StartDate, taskData.EndDate, userId);
            _logger.LogInformation("number of task(s) that overlap witht the new task is "+check.Count+"for the user with id : "+userId);
            if (check.Count == 0)
            {
                try
                {
                    var id = _taskRepository.Create(taskData).Result;
                    if (id > 0)
                        return true;
                }
                catch
                {
                    ExceptionManager.ThrowConflictException("task with same name exist");
                }
            }
            return false;
        }

        public bool DeleteTask(int taskId ,int userId)
        {
            var taskData = new TaskData() { Id = taskId, UserId = userId };
            var result = _taskRepository.Delete(taskData).Result;
            return result;
        }

        public List<TaskData> GetAllTasks(int userId, int limit, int skip)
        {
            var result = _taskRepository.GetAll(limit, skip, userId);
            _logger.LogInformation("the user with id : " + userId + " has " + result.Count + "tasks");
            return result;
        }

        public bool UpdateTask(TaskDto data, int userId,int taskId)
        {
            var taskData = new TaskData() { Id = taskId, Title = data.Title, EndDate = data.EndDate, StartDate = data.StartDate, UserId = userId };
            var check = _taskRepository.GetByPeriod(taskData.StartDate, taskData.EndDate, userId);
            _logger.LogInformation("number of task(s) that overlap witht the new task is " + check.Count + "for the user with id : " + userId);
            if (check.Count == 0 || (check.Count == 1 && check[0].Id == taskId))
            {
                var result = _taskRepository.Update(taskData).Result;
                return result;
            }
            return false;
        }
    }
}
