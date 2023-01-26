using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Persistence.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<UserData>().HasData(
                   new UserData() { Id = 1,UserName = "yazan",Password = "MTIzNDU2dGhpcyBpcyBteSBjdXN0b20gU2VjcmV0IGtleSBmb3IgYXV0aG5ldGljYXRpb24=" }
            );
            modelBuilder.Entity<TaskData>().HasData(
                    new TaskData() {Id = 1, Title = "Study",  StartDate = DateTime.Now,EndDate = DateTime.UtcNow.AddHours(-1),UserId = 1}

            );
        }
    }

}
