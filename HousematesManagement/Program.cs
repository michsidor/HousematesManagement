using Entity.Database;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Queries.Handlers;
using HousemateManagement.Models.Assignments.Repositories;
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
            builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); 
            builder.Services.AddMediatR(typeof(GetAllAssignmentsQueryHandler)); 
            builder.Services.AddMediatR(typeof(GetAssignmentQueryHandler)); // dodanie mediatora do kontenera DI
            builder.Services.AddMediatR(typeof(AddAssignmentCommandHandler)); // dodanie mediatora do kontenera DI
            builder.Services.AddMediatR(typeof(DeleteAssignmentCommandHandler)); // dodanie mediatora do kontenera DI
            builder.Services.AddMediatR(typeof(UpdateAssignmentCommandHandler)); // dodanie mediatora do kontenera DI

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