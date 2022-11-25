using K9P4EG_HFT_2022231.Logic;
using K9P4EG_HFT_2022231.Logic.Interfaces;
using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository;
using K9P4EG_HFT_2022231.Repository.Database;
using K9P4EG_HFT_2022231.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Endpoint
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TankDbContex>();

            services.AddTransient<Repo<Tank>, TankRepository>();
            services.AddTransient<Repo<Country>, CountryRepository>();
            services.AddTransient<Repo<Battle>, BattleRepository>();
           

            services.AddTransient<ITankLogic, TankLogic>();
            services.AddTransient<ICountryLogic, CountryLogic>();
            services.AddTransient<IBattleLogic, BattleLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "K9P4EG_HFT_2022231.Endpoint", Version = "v1" });
            });


        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "K9P4EG_HFT_2022231.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
