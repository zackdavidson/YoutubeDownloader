using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using StackExchange.Redis;
using YoutubeDownloader.Persistence;
using YoutubeDownloader.Persistence.Redis;
using YoutubeDownloader.Persistence.Repositories;
using YoutubeDownloader.Persistence.Repositories.Batch;
using YoutubeDownloader.YoutubeDl;

namespace YoutubeDownloader.WebApi
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
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddControllersAsServices();

            services.AddScoped<IYoutubeMetadataService, YoutubeMetadataService>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IBatchUploadService, BatchUploadService>();
            
            var redisConnectionString = Configuration.GetConnectionString("Redis");
            IConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);
            
            services.AddSingleton(redis);
            services.AddSingleton<IRedisService, RedisService>();

            var mysqlConnection = Configuration.GetConnectionString("Mysql");
            var mysqlVersion = new MySqlServerVersion(new Version(8, 0, 25));
            
            
            
            services.AddDbContext<YoutubeDownloaderContext>(options =>
            {
                options.UseMySql(mysqlConnection, mysqlVersion, x =>
                    x.MigrationsAssembly("YoutubeDownloader.Persistence"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, YoutubeDownloaderContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            db.Database.Migrate();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseStaticFiles(
                new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        // 7 days to cache static files
                        const int durationInSeconds = 604_800;
                        ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                            "public,max-age=" + durationInSeconds;  
                    },
                    FileProvider = new PhysicalFileProvider( Path.Combine(env.ContentRootPath, "StaticFiles/")),
                    RequestPath = "/static"
                });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}