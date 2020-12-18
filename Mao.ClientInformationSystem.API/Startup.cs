using Mao.ClientInformationSystem.Core.RepoInterfaces;
using Mao.ClientInformationSystem.Core.ServiceInterfacs;
using Mao.ClientInformationSystem.Infrastructure.Data;
using Mao.ClientInformationSystem.Infrastructure.Repos;
using Mao.ClientInformationSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mao.ClientInformationSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mao.ClientInformationSystem.API", Version = "v1" });
            });

            services.AddDbContext<ClientInformationSystemDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("ClientInformationSystemDbConnection"))));

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmpService, EmpService>();
            services.AddScoped<IIntService, IntService>();
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<IEmpRepo, EmpRepo>();
            services.AddScoped<IIntRepo, IntRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mao.ClientInformationSystem.API v1"));
            }

            //!enable cors
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
