using AspNedelja3.Implementation.Emails;
using ASPNedelja3.Application.Emails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using projekatASP.api.Core;
using projekatASP.api.Extensions;
using projekatASP.application.Logging;
using projekatASP.dataAccess;
using projekatASP.implementation;
using projekatASP.implementation.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace projekatASP.api
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
            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddHttpContextAccessor();
            services.AddJwt(settings);
            services.AddControllers();
            services.AddDbContext<projekatDbContext>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IUseCaseLogger, ConsoleUserExceptionLogger>();
            services.AddUseCases();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IDataBaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<IEmailSender>(x =>
           new SmtpEmailSender(settings.EmailOptions.FromEmail,
                               settings.EmailOptions.Password,
                               settings.EmailOptions.Port,
                               settings.EmailOptions.Host));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "projekatASP.api", Version = "v1" });
               var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "projekatASP.api v1"));
            }

            app.UseRouting();
            app.UseMiddleware<StatusCodesException>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
