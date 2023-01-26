using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TasksAPI.Business.Services;
using TasksAPI.Business.Services.Implementation;
using TasksAPI.Persistence.Data;
using TasksAPI.Persistence.Repsitories;
using TasksAPI.Persistence.Repsitories.Implementation;

namespace TasksAPI.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration _conf)
        { 

            services.AddDbContext<TaskDBContext>(options =>
            {
                var connectionString = _conf.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString );
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ITaskService,TaskService>();
        }
    } }
