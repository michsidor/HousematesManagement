using Entity.Database;
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
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly()); // dodanie mediatora do kontenera DI
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            builder.Services.AddDbContext<DatabaseContext>(
                    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value.ToString(),
                    b => b.MigrationsAssembly("HousemateManagement")));
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();    
            app.MapControllers();
            app.Run();
        }
    }
}