//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
//using ChrisCafe.Providers;

//namespace ChrisCafe
//{
//    public class Startup
//    {
//        readonly string AllowedOrigins = "_allowedOrigins";

//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            // Setup CORS for Google domains
//            // CORS setup ref: https://docs.microsoft.com/en-us/aspnet/core/security/cors
//            services.AddCors(options =>
//            {
//                options.AddPolicy(name: AllowedOrigins, builder =>
//                {
//                    builder.WithOrigins("https://www.googletagmanager.com", "https://www.google.com");
//                });
//            });

//            services.Configure<CookiePolicyOptions>(options =>
//            {
//                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                //  Ref: https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1

//                options.CheckConsentNeeded = context => true;
//                options.MinimumSameSitePolicy = SameSiteMode.None;
//            });

//            // Good refernece for .AddRazorPages() and related functions: https://www.strathweb.com/2020/02/asp-net-core-mvc-3-x-addmvc-addmvccore-addcontrollers-and-other-bootstrapping-approaches/
//            services.AddRazorPages();

//            // Custom services for dependency injection
//            //  Ref: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
//            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseStaticFiles();
//            app.UseCookiePolicy();
//            app.UseRouting();

//            //For most apps, certain options (UseAuthentication, UseAuthorization, UseCors) must appear between UseRouting and UseEndpoints.
//            app.UseCors(AllowedOrigins);

//            //Map routes/endpoints
//            app.UseEndpoints(endpoints =>
//            {
//                //The site works with only MapControllerRoute(), no MapRazorPages(). 
//                //  The site does NOT work without MapControllerRoute().
//                //  So I think MapRazorPages() is used for mixed-responsibility projects. (API + after-thought Razor pages? Or ASP Classic + Razor Pages?)
//                //Referenced source of confusion: .NET Core 2.2 -> 3.0 upgrade. https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-3.1&tabs=visual-studio#razor-pages
//                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
//            });

//            //Setup options for use with a reverse proxy (nginx).
//            app.UseForwardedHeaders(new ForwardedHeadersOptions
//            {
//                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
//            });
//        }
//    }
//}
