using Entity.Database;
using HousemateManagement.Models.Advertisements.Queries.Handler;
using HousemateManagement.Models.Advertisements.Commands.Handler;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Queries.Handlers;
using HousemateManagement.Models.Payments.Commands.Handler;
using HousemateManagement.Models.Payments.Queries.Handler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using HousemateManagement.Models.Advertisements.Repositories;
using HousemateManagement.Models.Payments.Repositories;
using HousemateManagement.Models.Assignments.Repositories;
using HousemateManagement.Models.User.Query.Handler;
using HousemateManagement.Models.User.Command.Handler;
using HousemateManagement.Models.User.Repository;
using Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using HousemateManagement.Models.Family.Command.Handler;
using HousemateManagement.Models.Family.Repository;

namespace HousemateManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //others
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatRHandlers();
            builder.Services.AddRepositoriesService();

            builder.Services.AddControllers().AddJsonOptions(j =>
            {
                j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); 
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
            app.UseSwagger();
            app.UseSwaggerUI(build =>
            {
                build.SwaggerEndpoint("/swagger/v1/swagger.json", "HousemateManagement");
            });
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();    
            app.MapControllers();
            app.Run();
        }
    }
}