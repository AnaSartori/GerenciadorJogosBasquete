using AutoMapper;
using GerenciadorJogosBasquete.Api.Dto;
using GerenciadorJogosBasquete.Domain.Interfaces.Repositories;
using GerenciadorJogosBasquete.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GerenciadorJogosBasquete.Domain.Services;
using GerenciadorJogosBasquete.Repository.Repositories;
using GerenciadorJogosBasquete.Repository.Connection;
using GerenciadorJogosBasquete.Repository.Interfaces;
using GerenciadorJogosBasquete.Domain.Dto;

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
            services.AddSwaggerGen(s=>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API de Gerenciamento de Jogos de Basquete", Version = "v1" });
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //AutoMapper
            AutoMapperConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
                app.UseHsts();
            }

            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void AutoMapperConfig(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JogoBasqueteDto, JogoBasquete>();
                cfg.CreateMap<JogoBasquete, JogoBasqueteDto>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
