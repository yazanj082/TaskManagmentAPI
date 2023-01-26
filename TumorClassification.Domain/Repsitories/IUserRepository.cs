using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Persistence.Data;

namespace TasksAPI.Persistence.Repsitories
{
    public interface IUserRepository
    {
        public Task<UserData> GetByUserNameAndPassword(UserData user);
        public Task<int> Add(UserData user);
    }
}
