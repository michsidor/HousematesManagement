using HousemateManagement.Models.Advertisements.Commands.Handler;
using HousemateManagement.Models.Advertisements.Queries.Handler;
using HousemateManagement.Models.Advertisements.Repositories;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Queries.Handlers;
using HousemateManagement.Models.Assignments.Repositories;
using HousemateManagement.Models.Family.Command.Handler;
using HousemateManagement.Models.Family.Repository;
using HousemateManagement.Models.Payments.Repositories;
using HousemateManagement.Models.User.Repository;

namespace HousemateManagement
{
    public static class RepositoriesServiceCollection
    {
        public static IServiceCollection AddRepositoriesService(this IServiceCollection services)
        {
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();

            return services;
        }
    }
}
