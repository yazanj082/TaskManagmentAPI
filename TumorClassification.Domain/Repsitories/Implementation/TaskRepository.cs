using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Persistence.Data;
using TasksAPI.Persistence.Helpers;

namespace TasksAPI.Persistence.Repsitories.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDBContext _context;
        public TaskRepository(TaskDBContext context)
        {
            this._context = context;
        }

        public Task<int> BulkCreate(List<TaskData> tasks)
        {
            _context.Task.AddRange(tasks);
            return _context.SaveChangesAsync();
        }

        public Task<int> Create(TaskData taskData)
        {
            _context.Add(taskData);
            return _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(TaskData taskData)
        {
            TaskData task = await GetById(taskData.Id,taskData.UserId);
            if (task != null)
            {
                _context.Remove(task);
                _context.Entry(task).State = EntityState.Deleted;
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public List<TaskData> GetAll(int limit, int skip , int userId)
        {
            IQueryable<TaskData> result = from e in _context.Task
                                          where e.UserId == userId
                                          select e;
            return result.Skip(skip).Take(limit).ToList();
        }

        public List<TaskData> GetByPeriod(DateTime start, DateTime end , int userId)
        {
            IQueryable<TaskData> result = from e in _context.Task.Where(x => ((x.StartDate < start && x.EndDate > start) || (x.StartDate < end && x.EndDate > end)||(x.StartDate == start)||(x.EndDate == end))
                                          && x.UserId == userId)
                                          select e;
            return result.ToList();
        }

        public async Task<bool> Update(TaskData taskData)
        {
            TaskData task = await GetById(taskData.Id, taskData.UserId);
            if (task != null)
            {
                task.Title = taskData.Title;
                task.StartDate = taskData.StartDate;
                task.EndDate = taskData.EndDate;
                _context.Update(task);
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        private Task<TaskData> GetById(int id, int userId)
        {
            IQueryable<TaskData> result = from e in _context.Task.Where(x => x.Id == id && x.UserId == userId)
                                          select e;
            return result.FirstOrDefaultAsync();
        }
    }
}
