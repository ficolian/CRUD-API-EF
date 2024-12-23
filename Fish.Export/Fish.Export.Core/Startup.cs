using Fish.Application.Usecase;
using Fish.Data;
using Fish.Web.API.Core.Extension;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fish.Web.API.Core
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

            services.ConfigureCors();
            services.ConfigureMVC(); //SET COMPATIBILITY, JSON FORMATTER, AND FLUENT VALIDATION
            services.AddMediatR(typeof(FindCustomerHandler).GetTypeInfo().Assembly); //REGISTER MEDIATR Object reference not set to an instance of an object.
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });
            services.ConfigureSwagger();
            services.AddHealthChecks();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yZgrQJc/0zwFbD1lZvwrwOHwOaAwdyzyjQzrtQl2SyE=")),
                            ValidIssuer = "your-issuer",
                            ValidAudience = "your-audience"
                        };
                    });
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/dev/swagger.json", "CUSTOMER.REST.API");
                c.RoutePrefix = "swagger";
            });
            //}

            //INITIALIZE USERPROFILE TO RETRIEVE ALL HTTP CONTEXT INFORMATION

            app.UseRouting();
            //ADD MIDDLEWARE
            

            app.UseHttpsRedirection();
            //app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            
        }
    }
}
