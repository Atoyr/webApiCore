using System;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using WebClient.Models;
using WebClient.Interfaces;
using WebClient.Models.Managers;
using WebClient.Models.Database;

namespace WebClient
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
            //services.Configure<SystemSettings>(this.Configuration.GetSection("SystemSettings"));

            var jwt = new Jwt{
               Key = this.Configuration["Jwt:Key"] ,
               Issuer = this.Configuration["Jwt:Issuer"] ,
               Audience = this.Configuration["Jwt:Audience"]
            };
            Console.WriteLine($"{jwt.Key},{jwt.Issuer},{jwt.Audience}");
            Console.WriteLine(KeyGenerator.GeneratKey());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer( options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience, 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            var sqlConBuilder = new SqlConnectionStringBuilder();

            var connection = this.Configuration["ConnectionStrings:Context"];
            if (string.IsNullOrEmpty(connection))
            {
                services.AddDbContext<Context>(options => options.UseInMemoryDatabase());
                var dbOpt = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase().Options;
                using (var context = new Context(dbOpt)){
                    var salt = Hash.GenerateSalt();
                    context.Users.Add(new User{Id = new Guid(), Hash = Hash.GetHash("a",salt), Salt = salt});
                    context.SaveChanges();

                    foreach(var user in context.Users)
                    {
                        Console.WriteLine($"Id {user.Id}");
                        Console.WriteLine($"Hash {user.Hash}");
                    }
                }
            }
            else
            {
                services.AddDbContext<Context>(options => options.UseSqlServer(connection));
            }

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            services.AddTransient<ITokenManager, TokenManager>();
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<IUserManager, UserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
