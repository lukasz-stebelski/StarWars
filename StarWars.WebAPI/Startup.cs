using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using StarWars.Model;
using StarWars.WebAPI.Extensions;
using StarWars.WebAPI.Options;
using System.Threading.Tasks;

namespace StarWars.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.AddSwagger();

             services.Configure<ConnectionOptions>(options => Configuration.GetSection("ConnectionStrings").Bind(options));

            string connectionString = Configuration.GetConnectionString("StarWarsDatabase");
            services.AddDbContext<StarWarsContext>(options => options.UseSqlServer(connectionString));
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register Autofac modules.
            builder.RegisterModule(new ServiceModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var apiOptions = app.ApplicationServices.GetService<IOptions<ApiOptions>>().Value;
                c.SwaggerEndpoint($"{apiOptions.AppFolder}/swagger/v1/swagger.json", "StarWars API");
            });

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

            app.Run(context => {

                var apiOptions = app.ApplicationServices.GetService<IOptions<ApiOptions>>().Value;
                context.Response.Redirect($"{apiOptions.AppFolder}/swagger");

                return Task.FromResult(0);
            });
        }
    }
}
