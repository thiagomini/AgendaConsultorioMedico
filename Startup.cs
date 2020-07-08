using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaConsultorioMedico.Business;
using AgendaConsultorioMedico.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace AgendaConsultorioMedico
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
            // Carregamento do .env e Banco de Dados
            DotNetEnv.Env.Load();
            services.AddDbContext<AgendaDBContext>(options => options.UseSqlServer
                (System.Environment.GetEnvironmentVariable("CONNECTION_STRING")));
            services.AddControllers();

            // Injeção de dependência das demais classes
            services.AddScoped<IPeopleRepository, SqlPeopleRepository>();
            services.AddScoped<IAppointmentsRepository, SqlAppointmentsRepository>();
            services.AddScoped<IAppointmentValidation, EqualTimeAppointmentValidation>();
            
            // Injeção do mapeamento de model < - > Dto
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Tratar de JSON em PATCH
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
