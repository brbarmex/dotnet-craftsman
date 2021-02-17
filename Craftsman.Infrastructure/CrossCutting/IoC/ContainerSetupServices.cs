using Craftsman.Domain.Handlers.CustomerUseCases;
using Craftsman.Domain.Interfaces.ICustomer;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Infrastructure.DataBase.Interface;
using Craftsman.Infrastructure.DataBase.UoW;
using Craftsman.Infrastructure.Gateways.ViaCep.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Craftsman.Infrastructure.CrossCutting.IoC
{
    public static class ContainerService
    {
        public static void RegisterUseCases(this IServiceCollection service)
        {
            service.AddScoped<ICreateCustomerService, CreateCustomer>();
        }

        public static void RegisterGateway(this IServiceCollection service)
        {
            service.AddScoped<IZipCodeServices, ViaCepGateway>();
        }

        public static void RegisterDataBase(this IServiceCollection services)
        => services.AddScoped<CraftsmanContext>();

        public static void RegisterUnitOfWork(this IServiceCollection services)
        => services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}