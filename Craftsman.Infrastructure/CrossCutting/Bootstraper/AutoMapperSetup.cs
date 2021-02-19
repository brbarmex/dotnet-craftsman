using AutoMapper;
using Craftsman.Infrastructure.Automapper;
using Microsoft.Extensions.DependencyInjection;

namespace Craftsman.Infrastructure.CrossCutting.Bootstraper
{
    public static class AutoMapperSetup
    {
        public static void AutoMapperEnable(this IServiceCollection services)
        {
            var automapperConfiguration = new MapperConfiguration
            (config => config.AddProfile(new DomainToDataBase()));

            IMapper _mapper = automapperConfiguration.CreateMapper();

            services.AddSingleton(_mapper);
        }
    }
}