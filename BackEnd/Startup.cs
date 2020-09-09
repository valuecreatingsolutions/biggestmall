using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Antiforgery;
using BackEnd.Data;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace BackEnd
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
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build()
                );

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MyConnection")));

            var _appIdentitySettings = Configuration.GetSection("AppIdentitySettings");
            var appIdentitySettings = _appIdentitySettings.Get<AppIdentitySettings>();

            //Inject AppIdentitySettings so that can be used anywhere.
            services.Configure<AppIdentitySettings>(_appIdentitySettings);

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
                options.Stores.MaxLengthForKeys = 128;

                // User Settings
                options.User.RequireUniqueEmail = appIdentitySettings.User.RequireUniqueEmail;

                // Password settings
                options.Password.RequireDigit = appIdentitySettings.Password.RequireDigit;
                options.Password.RequiredLength = appIdentitySettings.Password.RequiredLength;
                options.Password.RequireLowercase = appIdentitySettings.Password.RequireLowerCase;
                options.Password.RequireUppercase = appIdentitySettings.Password.RequireUpperCase;
                options.Password.RequireNonAlphanumeric = appIdentitySettings.Password.RequireNonAlphaNumeric;

                //Lockout Settings
                options.Lockout.AllowedForNewUsers = appIdentitySettings.Lockout.AllowedForNewUsers;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(appIdentitySettings.Lockout.DefaultLockoutTimeSpanInMins);
                options.Lockout.MaxFailedAccessAttempts = appIdentitySettings.Lockout.MaxFailedAccessAttempts;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddGoogle(options => { options.ClientId = Configuration["Authentication:Google:ClientId"]; options.ClientSecret = Configuration["Authentication:Google:ClientSecret"]; })
                .AddTwitter(options => { options.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"]; options.ConsumerSecret = Configuration["Authentication:Twitter:CosumerSecrect"]; })
                .AddFacebook(options => { options.AppId = Configuration["Authentication:Facebook:AppId"]; options.AppSecret = Configuration["Authentication:Facebook:AppSecret"]; })
                .AddCookie(options => {
                    options.LoginPath = "~/Account/Login";
                    options.LogoutPath = "~/Account/Logout";
                });
            services.AddAntiforgery(options => {
                options.FormFieldName = "AntiforgeryFieldName";
                options.HeaderName = "X-CRSF-TOKEN-HEADERNAME";
                options.SuppressXFrameOptionsHeader = false;
            });
            services.AddMvc();

            /*
            services.AddJsReport(new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .AsUtility()
                .Create());*/

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            CreateUsersAndRoles(app);

            app.Use(next => context => {
                string path = context.Request.Path.Value;
                if (string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) || string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false });
                }

                return next(context);
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public async void CreateUsersAndRoles(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //if there is already an Administrator role, abort
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                IdentityResult identityResult;
                var roleCheck = await _roleManager.RoleExistsAsync("Super Administrator");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Super Administrator"));
                    // Check if the user exists
                    string user = "admin@biggest-mall.com";
                    string uname = "SuperAdmin";
                    string password = "Maks%123";

                    var _user = new ApplicationUser { UserName = uname, Email = user, EmailConfirmed = true };
                    var success = await _userManager.CreateAsync(_user, password);
                    if (success.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(uname), "Super Administrator");
                    }
                }

                roleCheck = await _roleManager.RoleExistsAsync("Administrator");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Administrator"));
                }
                roleCheck = await _roleManager.RoleExistsAsync("Registrar");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Registrar"));
                }
                roleCheck = await _roleManager.RoleExistsAsync("Academic");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Academic"));
                }

                roleCheck = await _roleManager.RoleExistsAsync("Student Administration");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Student Administration"));
                }

                roleCheck = await _roleManager.RoleExistsAsync("Marketing");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Marketing"));
                }

                roleCheck = await _roleManager.RoleExistsAsync("Finance");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Finance"));
                }

                roleCheck = await _roleManager.RoleExistsAsync("Student");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Student"));
                }

                roleCheck = await _roleManager.RoleExistsAsync("Lecturer");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Lecturer"));
                }
                roleCheck = await _roleManager.RoleExistsAsync("Mentor");
                if (!roleCheck)
                {
                    identityResult = await _roleManager.CreateAsync(new ApplicationRole("Mentor"));
                }
            };
        }
    }
}
