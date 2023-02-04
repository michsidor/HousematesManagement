using Entity.Database;
using HousemateManagement.Tasks.Commands.Handlers;
using HousemateManagement.Tasks.Repositories;
using HousematesManagement.Tasks.Queries.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HousemateManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); 
            builder.Services.AddMediatR(typeof(GetAllTaskQueryHandler)); 
            builder.Services.AddMediatR(typeof(GetTaskQueryHandler)); // dodanie mediatora do kontenera DI
            builder.Services.AddMediatR(typeof(AddTaskCommandHandler)); // dodanie mediatora do kontenera DI
            builder.Services.AddMediatR(typeof(DeleteTaskCommandHandler)); // dodanie mediatora do kontenera DI
            builder.Services.AddMediatR(typeof(UpdateTaskCommandHandler)); // dodanie mediatora do kontenera DI

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DatabaseContext>(
                    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value.ToString(),
                    b => b.MigrationsAssembly("HousemateManagement")));
            builder.Services.AddCors(options => {
                options.AddPolicy("MyOwnPolicy", build =>
                {
                    build.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin();
                });
            });
            var app = builder.Build();
            app.UseCors("MyOwnPolicy");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();    
            app.MapControllers();
            app.Run();
        }
    }
}