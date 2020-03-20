using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using GerenciadorJogosBasquete.Api.Dto;
using GerenciadorJogosBasquete.Domain.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using GerenciadorJogosBasquete.Domain.Services;
using GerenciadorJogosBasquete.Repository.Connection;
using GerenciadorJogosBasquete.Repository.Interfaces;
using GerenciadorJogosBasquete.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorJogosBasquete.Api
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
            //Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API de Gerenciamento de Jogos de Basquete", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            //IoC
            services.AddSingleton<IJogoService, JogoService>();
            services.AddSingleton<IJogoRepository, JogoRepository>();
            services.AddSingleton<IConnectionFactory, DefaultSqlConnectionFactory>();

            //Mvc
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //AutoMapper
            AutoMapperConfig(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                s.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void AutoMapperConfig(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JogoBasqueteRequestDto, JogoBasquete>();
                cfg.CreateMap<JogoBasquete, JogoBasqueteRequestDto>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
