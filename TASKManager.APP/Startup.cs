using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TASKManager.Infra.Data;
using TASKManager.Infra.IOC;

namespace TASKManager.APP
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(opt => opt.UseMySql(Configuration["ConnectionStrings:TASKManager"], b => b.MigrationsAssembly("TASKManager.APP")));
        }

        public void ConfigureContainer(ContainerBuilder builder) => builder.RegisterModule(new ModuleIOC());

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller=TaskManager}/{action=Index}/{id?}"));
        }
    }
}
