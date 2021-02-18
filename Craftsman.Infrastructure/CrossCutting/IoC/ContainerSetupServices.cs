using Craftsman.Domain.Handlers.CustomerUseCases;
using Craftsman.Domain.Interfaces.ICustomer;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Infrastructure.DataBase.Repositories;
using Craftsman.Infrastructure.DataBase.UoW;
using Craftsman.Infrastructure.Gateways.ViaCep.Services;
using Craftsman.Infrastructure.Settings;
using Craftsman.Shared.Bases;
using Craftsman.Shared.DomainNotification;
using Craftsman.Shared.Interfaces;
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
            service.AddHttpClient("viaCep", x => x.BaseAddress = new System.Uri(GlobalSettings.UrlViaCep));
        }

        public static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public static void RegisterDataBase(this IServiceCollection services)
        => services.AddScoped<CraftsmanContext>();

        public static void RegisterUnitOfWork(this IServiceCollection services)
        => services.AddTransient<IUnitOfWork, UnitOfWork>();

        public static void RegisterNotifications(this IServiceCollection services)
        => services.AddScoped<INotifications, DomainNotification>();
    }
}