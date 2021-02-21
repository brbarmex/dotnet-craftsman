using AutoMapper;
using Craftsman.Infrastructure.Automapper;
using Microsoft.Extensions.DependencyInjection;

namespace Craftsman.Infrastructure.CrossCutting.Bootstraper
{
    public static class AutoMapperSetup
    {
        public static void AutoMapperEnable(this IServiceCollection services)
        => services
          .AddSingleton(
              new MapperConfiguration(config =>
              {
                  config.AddProfile(new DomainToDataBase());
                  config.AddProfile(new DataBaseToDomain());
              })
              .CreateMapper());
    }
}