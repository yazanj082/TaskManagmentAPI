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
    public class UserRepository : IUserRepository
    {
        private readonly TaskDBContext _context;
        public UserRepository(TaskDBContext context)
        {
            this._context = context;
        }

        public Task<int> Add(UserData user)
        {
            user.Password = DataHelpers.EncodePass(user.Password);
            _context.Add(user);
            return _context.SaveChangesAsync();

        }

        public Task<UserData> GetByUserNameAndPassword(UserData user)
        {
            IQueryable<UserData> result = from e in _context.User.Where(x => x.UserName == user.UserName && x.Password == DataHelpers.EncodePass(user.Password) )
                                    select e;
            return result.FirstOrDefaultAsync();
        }
    }
}
