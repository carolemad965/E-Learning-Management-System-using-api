
using E_Learning_Management_System.Models;
using E_Learning_Management_System.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using E_Learning_Management_System.Controllers;

namespace E_Learning_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program)); //auto mapper
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));

            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                                  policy => policy.AllowAnyMethod()
                                  .AllowAnyOrigin()
                                  .AllowAnyHeader());
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //[authore ]:found toke or not
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //account/loginresonse unauthorize
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAud"],
                    IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecritKey"]))
                };
            });


            /*-----------------------------Swagger PArt-----------------------------*/
            #region Swagger REgion
            //builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 5 Web API",
                    Description = " ITI Projrcy"
                });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                    }
                    },
                    new string[] {}
                    }
                    });
            });
            #endregion
            //----------------------------------------------------------

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

            //builder.Services.AddScoped<IRepository<Course>, Repository<Course>>();
            builder.Services.AddScoped<IRepository<Instructor>, Repository<Instructor>>();
            builder.Services.AddScoped<IRepository<Learner>, Repository<Learner>>();
         builder.Services.AddScoped<IRepository<Adminstrator>, Repository<Adminstrator>>();

            builder.Services.AddScoped<IRepository<Certificate>, Repository<Certificate>>();
            builder.Services.AddScoped<IRepository<Quiz>, Repository<Quiz>>();

            builder.Services.AddScoped<IRepository<TheQuizzes>, Repository<TheQuizzes>>();
            builder.Services.AddScoped<IRepository<Content>, Repository<Content>>();
            builder.Services.AddScoped<IRepository<Quiz>, Repository<Quiz>>();


            var app = builder.Build();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");
            app.UseAuthorization();


            app.MapControllers();

                       

            app.Run();
        }
    }
}
