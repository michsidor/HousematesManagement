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
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddSwaggerGen();


            //repositories
            builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();

            // assignment
            builder.Services.AddMediatR(typeof(GetAllAssignmentsQueryHandler)); 
            builder.Services.AddMediatR(typeof(GetAssignmentQueryHandler)); 
            builder.Services.AddMediatR(typeof(AddAssignmentCommandHandler)); 
            builder.Services.AddMediatR(typeof(DeleteAssignmentCommandHandler)); 
            builder.Services.AddMediatR(typeof(UpdateAssignmentCommandHandler));

            //advertisements
            builder.Services.AddMediatR(typeof(GetAllAdvertisementsQueryHandler));
            builder.Services.AddMediatR(typeof(GetDirectAdvertisementsQueryHandler));
            builder.Services.AddMediatR(typeof(AddAdvertisementCommandHandler));
            builder.Services.AddMediatR(typeof(DeleteAdvertisementCommandHandler));
            builder.Services.AddMediatR(typeof(UpdateAdvertisementCommandHandler));

            //payments
            builder.Services.AddMediatR(typeof(GetAllPaymentsQueryHandler));
            builder.Services.AddMediatR(typeof(GetDirectPaymentsQueryHandler));
            builder.Services.AddMediatR(typeof(AddPaymentCommandHandler));
            builder.Services.AddMediatR(typeof(DeletePaymentCommandHandler));
            builder.Services.AddMediatR(typeof(UpdatePaymentCommandHandler));

            //user
            builder.Services.AddMediatR(typeof(LoginUserQueryHandler));
            builder.Services.AddMediatR(typeof(RegisterUserCommandHandler));

            //family
            builder.Services.AddMediatR(typeof(LoginToFamilyCommandHandler));
            builder.Services.AddMediatR(typeof(AddFamilyCommandHandler));

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