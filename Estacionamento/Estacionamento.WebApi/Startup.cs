using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Estacionamento.Repository.DataContext;
using Estacionamento.Repository.Interfaces;
using Estacionamento.Repository.Repositorys;
using Estacionamento.Application.Interfaces;
using Estacionamento.Application.Services;
using AutoMapper;
// using Estacionamento.WebApi.Auth;

namespace Estacionamento.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EstacionamentoDataContext>(options => options.UseSqlServer(_configuration.GetConnectionString("database")));
            services.AddControllers();
            services.AddHttpClient();

            services.AddAutoMapper ();
            this._ConfigureInjectionDependecy (services);

            // services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Estacionamento.WebApi", Version = "v1" });
            });

            services.AddCors ();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estacionamento.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void _ConfigureInjectionDependecy (IServiceCollection services) {
                services
                    .AddScoped<ICarroRepository, CarroRepository> ()
                    .AddScoped<IPessoaRepository, PessoaRepository> ()
                    .AddScoped<IManobristaRepository, ManobristaRepository> ()

                    .AddScoped<ICarroService, CarroService> ()
                    .AddScoped<IPessoaService, PessoaService> ()
                    .AddScoped<IManobristaService, ManobristaService> ();
        }
    }
}
