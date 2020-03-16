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
using PruebaDB.Repositories.Product;
using PruebaDB.Utils;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

namespace PruebaAPI
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
            });

            services.AddControllers().AddJsonOptions((opt) =>
            {
                // opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = null
            };

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy",
                           builder =>
                           {
                               builder.AllowAnyOrigin()
                                    .WithOrigins("http://127.0.0.1:3000", "http://localhost:3000")
                                    //                        "http://127.0.0.1:5500/FrontEnd.html")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                           });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Contact = new OpenApiContact { Name = "Edward Bustos", Email = "esbgo97@gmail.com" },
                    Title = "Prueba DigitalWare"
                });
            });
            services.AddScoped<DbContext, AppDbContext>();
            services.AddTransient<IProductRepository, ProductRep>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("DefaultPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HiveSystem API V1");
            });
        }
    }
}
