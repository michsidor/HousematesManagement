using HousemateManagement.Models.Advertisements.Commands.Handler;
using HousemateManagement.Models.Advertisements.Queries.Handler;
using HousemateManagement.Models.Assignments.Commands.Handlers;
using HousemateManagement.Models.Assignments.Queries.Handlers;
using HousemateManagement.Models.Family.Command.Handler;
using HousemateManagement.Models.Payments.Commands.Handler;
using HousemateManagement.Models.Payments.Queries.Handler;
using HousemateManagement.Models.User.Command.Handler;
using HousemateManagement.Models.User.Query.Handler;
using MediatR;
using System.Reflection;

namespace HousemateManagement
{
    public static class MediatRServiceCollection
    {
        public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //assignment
            services.AddMediatR(typeof(GetAllAssignmentsQueryHandler));
            services.AddMediatR(typeof(GetAssignmentQueryHandler));
            services.AddMediatR(typeof(AddAssignmentCommandHandler));
            services.AddMediatR(typeof(DeleteAssignmentCommandHandler));
            services.AddMediatR(typeof(UpdateAssignmentCommandHandler));

            //advertisements
            services.AddMediatR(typeof(GetAllAdvertisementsQueryHandler));
            services.AddMediatR(typeof(GetDirectAdvertisementsQueryHandler));
            services.AddMediatR(typeof(AddAdvertisementCommandHandler));
            services.AddMediatR(typeof(DeleteAdvertisementCommandHandler));
            services.AddMediatR(typeof(UpdateAdvertisementCommandHandler));

            //payments
            services.AddMediatR(typeof(GetAllPaymentsQueryHandler));
            services.AddMediatR(typeof(GetDirectPaymentsQueryHandler));
            services.AddMediatR(typeof(AddPaymentCommandHandler));
            services.AddMediatR(typeof(DeletePaymentCommandHandler));
            services.AddMediatR(typeof(UpdatePaymentCommandHandler));

            //user
            services.AddMediatR(typeof(LoginUserQueryHandler));
            services.AddMediatR(typeof(RegisterUserCommandHandler));

            //family
            services.AddMediatR(typeof(LoginToFamilyCommandHandler));
            services.AddMediatR(typeof(AddFamilyCommandHandler));

            return services;
        }
    }
}
