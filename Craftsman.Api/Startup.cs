using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Craftsman.Infrastructure.CrossCutting.IoC;
using Craftsman.Infrastructure.CrossCutting.Bootstraper;

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
            .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Craftsman.Api", Version = "v1" }))
            .AddControllers();

            services.RegisterDataBase();
            services.RegisterUnitOfWork();
            services.RegisterRepositories();
            services.RegisterGateway();
            services.RegisterUseCases();
            services.RegisterNotifications();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                .UseDeveloperExceptionPage()
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Craftsman.Api v1"));
            }

            app
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
