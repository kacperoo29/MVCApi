using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NHibernate;

namespace MVCApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MVCApi", Version = "v1" });
            });

            services.AddScoped<ISessionFactory>(s => Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile("firstProject.db")
                    )
                .Mappings(m =>
                //TODO: Change Program to any mapping class
                    m.FluentMappings.AddFromAssemblyOf<Program>())
                .BuildSessionFactory());

            // TODO: Add any assembly from Application layer
            //services.AddMediatR(typeof());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MVCApi v1"));
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
