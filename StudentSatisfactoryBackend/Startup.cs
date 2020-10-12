using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudentSatisfactoryBackend.Data;
using StudentSatisfactoryBackend.Extension;
using StudentSatisfactoryBackend.Models;
using StudentSatisfactoryBackend.Repositories;
using StudentSatisfactoryBackend.Repositories.AdminRepository;
using StudentSatisfactoryBackend.Repositories.CourseRepository;
using StudentSatisfactoryBackend.Repositories.CourseRepository.Interfaces;
using StudentSatisfactoryBackend.Repositories.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepository.Interfaces;
using StudentSatisfactoryBackend.Repositories.UserRepsitory;
using StudentSatisfactoryBackend.Services.LoginManager;
using System;

namespace StudentSatisfactoryBackend
{
    public class Startup
    {
        public static ClientData ClientData { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });
            services.ConfigureIISIntegration();

            services.AddControllers();
            services.AddDbContextPool<SurveyContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SurveyConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<SurveyContext>().AddDefaultTokenProviders();

            services.AddAuthentication()
            .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                    ClientData = googleAuthNSection.Get<ClientData>();
                });

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<IAdminRepository, AdminRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
