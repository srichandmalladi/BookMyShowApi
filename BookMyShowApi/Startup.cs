using BookMyShowApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using BookMyShowApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using SimpleInjector;
using BookMyShowApi.Services;

namespace BookMyShowApi
{
    public class Startup
    {
        private readonly string CorsPolicy = "_cors";
        private Container container = new Container();
        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<AuthenticationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("authenticationContext")));

            services.AddIdentity<User,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddCors();

            //Jwt Authentication
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddCors(
                options =>
                {
                    options.AddPolicy(name: CorsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
                }
            );
            services.AddControllersWithViews();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation()
                    .AddPageModelActivation()
                    .AddTagHelperActivation();

                options.AddLogging();
                options.AddLocalization();

                container.Register<IMovieService, MovieService>();
                container.Register<ITheatreService, TheatreService>();
                container.Register<ITicketService, TicketService>();
                container.Register<IShowService, ShowService>(Lifestyle.Transient);
                container.Register<IDataBaseContext, DataBaseContext>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(CorsPolicy);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            container.Verify();
        }
    }
}
