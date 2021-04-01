using Hangfire.Api.Abstract;
using Hangfire.Api.Concrete;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hangfire.Api
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

          services.AddHangfire(configuration => configuration
         .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
         .UseSimpleAssemblyNameTypeSerializer()
         .UseRecommendedSerializerSettings()
         .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
         {
             CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
             SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
             QueuePollInterval = TimeSpan.Zero,
             UseRecommendedIsolationLevel = true,
             DisableGlobalLocks = true
         }));

            services.AddHangfireServer();
            // Add framework services.
            //services.AddMvc();


            //services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IMailService, MailManager>();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //services.Configure<SmtpConfigDto>(Configuration.GetSection("SmtpConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBackgroundJobClient backgroundJobs)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireDashboard();
            backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
