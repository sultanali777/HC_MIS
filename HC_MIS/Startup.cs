
using HC_MIS.Models;
using HC_MIS.Data;
using HC_MIS.Permission;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NToastNotify;

namespace HC_MIS
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
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSwaggerGen();

            services.AddDbContext<HC_DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HC_DbContext>()
                    .AddDefaultUI()
            .AddDefaultTokenProviders();
            //services.AddSpaStaticFiles(c => { c.RootPath = "adminlte"; });
            services.AddCors(cors => cors.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<SMTPSettings>(Configuration.GetSection("SMTPSettings"));
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseStaticFiles();
            //app.UseSpaStaticFiles(new StaticFileOptions()
            //{
            //    OnPrepareResponse = context =>
            //    {
            //        context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            //        context.Context.Response.Headers["Pragma"] = "no-cache";
            //        context.Context.Response.Headers.Add("Expires", "-1");
            //    }
            //});
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "app";
            //    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            //    {
            //        OnPrepareResponse = context =>
            //        {
            //            // never cache index.html
            //            if (context.File.Name == "index.html")
            //            {
            //                context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            //                context.Context.Response.Headers.Add("Expires", "-1");
            //            }
            //        }
            //    };
            //});
            app.UseCors("MyPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
            });

            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()

            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}