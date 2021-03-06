﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegracionBancaria.Model;
using IntegracionBancaria.Model.Data.Dapper;
using IntegracionBancaria.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntegracionBancaria
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddLogging();
            services.AddOptions();
            services.AddMvc();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.CookieHttpOnly = true;
            });

            services.Configure<AppSettings>(x => Configuration.GetSection("AppSettings").Bind(x));

            // Daos
            services.AddSingleton<ComentarioDao, ComentarioDao>();
            services.AddSingleton<BancoDao, BancoDao>();
            services.AddSingleton<PerfilDao, PerfilDao>();
            services.AddSingleton<UsuarioDao, UsuarioDao>();
            services.AddSingleton<TransaccionDao, TransaccionDao>();
            services.AddSingleton<BitacoraDao, BitacoraDao>();

            // Servicios
            services.AddSingleton<ServicioCriptografia, ServicioCriptografia>();
            services.AddSingleton<ServicioComentario, ServicioComentario>();
            services.AddSingleton<ServicioBanco, ServicioBanco>();
            services.AddSingleton<ServicioRegistro, ServicioRegistro>();
            services.AddSingleton<ServicioInicioSesion, ServicioInicioSesion>();
            services.AddSingleton<ServicioTransaccion, ServicioTransaccion>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
