using Craftsman.Domain.Handlers.CustomerUseCases;
using Craftsman.Domain.Interfaces.ICustomer;
using Craftsman.Domain.Interfaces.IGateway;
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
    }
}