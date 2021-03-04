using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using Craftsman.Infrastructure.CrossCutting.Bootstraper;
using Craftsman.Infrastructure.CrossCutting.IoC;

namespace Craftsman.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.LoadSetting();

            services
            .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "The craftsman.", Version = "v1" }))
            .AddControllers();

            services.AddCors();
            services.RegisterDataBase();
            services.RegisterUnitOfWork();
            services.RegisterRepositories();
            services.RegisterGateway();
            services.RegisterUseCases();
            services.RegisterNotifications();
            services.AutoMapperEnable();
            services.AddMediatR(typeof(Startup));
            services.AddRouting(opt => opt.LowercaseUrls = opt.LowercaseQueryStrings = true);

            FluentMap.LoadMapping();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                .UseDeveloperExceptionPage()
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "The craftsman."));
            }

            app
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers())
            .UseCors(opt => opt.AllowAnyOrigin());
        }
    }
}
