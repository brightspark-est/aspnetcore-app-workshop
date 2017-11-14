using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using FrontEnd.Filters;
using Microsoft.AspNetCore.Authentication;
using Data;
using Microsoft.EntityFrameworkCore;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Identity;
using Data.Models;

namespace FrontEnd
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddMvc(options =>
                {
                    options.Filters.AddService(typeof(RequireLoginFilter));
                });

            services.AddScoped<RequireLoginFilter>();

            var authBuilder = services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/Denied";
                });




            SetupTwitter(authBuilder);
            SetupGoogle(authBuilder);

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(Configuration["serviceUrl"])
            };

            services.AddSingleton(httpClient);
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<IApiClient, ApiClient>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser()
                          .RequireUserName(Configuration["admin"]);
                });
            });

        }

        private void SetupTwitter(AuthenticationBuilder authBuilder)
        {
            var twitterConfig = Configuration.GetSection("twitter");
            if (twitterConfig["consumerKey"] != null)
            {
                authBuilder.AddTwitter(options => twitterConfig.Bind(options));
            }
        }

        private void SetupGoogle(AuthenticationBuilder authBuilder)
        {
            var googleConfig = Configuration.GetSection("google");
            if (googleConfig["clientID"] != null)
            {
                authBuilder.AddGoogle(options => googleConfig.Bind(options));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Attendees}/{action=Index}/{id?}");
            });
        }
    }
}