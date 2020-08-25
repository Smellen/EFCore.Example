using AutoMapper;
using System.Reflection;
using EFCore.Example.Domain.DomainServices;
using EFCore.Example.Domain.Interfaces;
using EFCore.Example.Infrastructure;
using EFCore.Example.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EFCore.Example.Application;

namespace EFCore.Example
{
    public class Startup
    {
        private const string ApiName = "Ellen EFCore.Example API V1";
        private const string SwaggerPath = "/swagger/v1/swagger.json";
        private const string HealthEndpoint = "/health";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ExampleDbContext>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionString"], sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
                });

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile)); // TODO: Actually create the mapping profile.

            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerPath, ApiName);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks(HealthEndpoint);
            });
        }
    }
}
