using BoardGames.Data;
using BoardGames.Email;
using BoardGamesContextLib;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BoardGames
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
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => 
            {
                bool requireConfirmed = bool.Parse(Configuration["RequireConfirmedAccount"]);
                options.SignIn.RequireConfirmedAccount = requireConfirmed;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            AddAuthentication(services);

            services.AddDbContext<BoardGameContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BoardGames;Trusted_Connection = True; MultipleActiveResultSets = true"));
            services.AddScoped<IBoardGameContext, BoardGameContext>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

        }

        private void AddAuthentication(IServiceCollection services)
        {
            bool useAuthentication = bool.Parse(Configuration["Authentication:Enabled"]);
            if (!useAuthentication)
            {
                return;
            }

            services.AddAuthentication()
                            .AddMicrosoftAccount(microsoftOptions =>
                            {
                                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                            })
                            .AddFacebook(facebookOptions =>
                            {
                                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                                facebookOptions.AccessDeniedPath = "/Identity/Account/AccessDenied";
                            })
                            .AddGoogle(options =>
                            {
                                IConfigurationSection googleAuthNSection =
                                    Configuration.GetSection("Authentication:Google");

                                options.ClientId = googleAuthNSection["ClientId"];
                                options.ClientSecret = googleAuthNSection["ClientSecret"];
                            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
