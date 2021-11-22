using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Estacionamento.Repository.DataContext;
using Estacionamento.Repository.Interfaces;
using Estacionamento.Repository.Repositorys;
using Estacionamento.Application.Interfaces;
using Estacionamento.Application.Services;
using AutoMapper;
using Estacionamento.WebApi.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;

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
            this._ConfigureAuth (services);
            this._ConfigureSwagger(services);

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
            app.UseAuthentication();
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

        private void _ConfigureAuth (IServiceCollection services) {
            var tokenConfigurations = new TokenConfiguration ();
            new ConfigureFromConfigurationOptions<TokenConfiguration> (_configuration
                    .GetSection ("TokenSettings"))
                .Configure (tokenConfigurations);

            services.AddSingleton (tokenConfigurations);

            services.AddAuthentication (authOptions => {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (bearerOptions => {
                bearerOptions.SaveToken = true;

                bearerOptions.TokenValidationParameters = new TokenValidationParameters () {
                    IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (tokenConfigurations.SecretyKey)),
                    ValidAudience = tokenConfigurations.Audience,
                    ValidIssuer = tokenConfigurations.Issuer,
                    ClockSkew = TimeSpan.Zero,

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true

                };
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization (auth => {
                auth.AddPolicy ("Bearer", new AuthorizationPolicyBuilder ()
                    .AddAuthenticationSchemes (JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser ().Build ());
            });
        }

        private void _ConfigureSwagger (IServiceCollection services) {
            services.AddSwaggerGen (s => {
                s.SwaggerDoc ("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Estacionamento API",
                    Description = "API responsável pela integração",
                    License = new OpenApiLicense{
                        Name = "Estacionamento",
                        Url = new Uri("https://github.com/luicesar")
                        },
                });

                s.AddSecurityDefinition ("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type =  SecuritySchemeType.Http,
                    Description = "JWT Authorization header use o schema Bearer. Exemplo: \"Authorization: Bearer {token}\"",
                });

                var openApiSecurityRequirement =new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                },
                        },
                        new string[]{}
                    }
                };

                s.AddSecurityRequirement(openApiSecurityRequirement);

            });
        }
    }
}
