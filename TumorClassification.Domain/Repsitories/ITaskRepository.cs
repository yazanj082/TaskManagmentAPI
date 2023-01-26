using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Persistence.Data;

namespace TasksAPI.Persistence.Repsitories
{
    public interface ITaskRepository
    {
        public Task<int> Create(TaskData taskData);
        public Task<bool> Update(TaskData taskData);
        public Task<bool> Delete(TaskData taskData);
        public List<TaskData> GetAll(int limit,int skip, int userId);
        public List<TaskData> GetByPeriod(DateTime start, DateTime end, int userId);
        public Task<int> BulkCreate (List<TaskData> tasks);
    }
}
