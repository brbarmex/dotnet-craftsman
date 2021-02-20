using System;
using System.Collections.Generic;
using Craftsman.Application.Boudaries.Customer.CommandHandler;
using Craftsman.Application.Boundaries.Customer.Commands;
using Craftsman.Domain.Bases;
using Craftsman.Domain.DomainNotification;
using Craftsman.Domain.Entities;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.IGateway;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Infrastructure.DataBase.Repositories;
using Craftsman.Infrastructure.DataBase.UoW;
using Craftsman.Infrastructure.Gateways.ViaCep.Services;
using Craftsman.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OneOf;

namespace Craftsman.Infrastructure.CrossCutting.IoC
{
    public static class ContainerService
    {
        public static void RegisterUseCases(this IServiceCollection service)
        {
            service.AddScoped<IRequestHandler<CreateCommand, OneOf<List<Notification>, Customer, Exception>>, CreateCommandHandler>();
        }

        public static void RegisterGateway(this IServiceCollection service)
        {
            service.AddScoped<IZipCodeServices, ViaCepGateway>();
            service.AddHttpClient("viaCep", x => x.BaseAddress = new Uri(GlobalSettings.UrlViaCep));
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