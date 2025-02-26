using Grind.Core.Interfaces;
using Grind.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Grind.Service;
using Grind.Data;
using Grind.Core.Dots;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Grind.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

            });

            //הזרקת תלויות
            //builder.Services.AddSingleton<IDataContext,DataContext>();
            builder.Services.AddDbContext<DataContext>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"], // שינוי כאן
                    ValidAudience = builder.Configuration["Jwt:Audience"], // שינוי כאן
                    ClockSkew = TimeSpan.Zero,//בודק האם לא פג התוקף
                    //השורה הבאה שונה משל המורה- היתה לי שגיאה על המילה קונפיגוריישן
                    //והמ'אט אמר לי לעשות בילדר נקודה קונפיגוריישן- כי הוא לא מוגדר
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
                });
            //יצירת מידלוואר, שיבצע כתיבה ללוג לפני ואחרי הקריאה לאייפיאיי
            var app = builder.Build();
            app.Use(async (context, next) =>
            {
                var endpoint = context.GetEndpoint();
                var actionName = endpoint?.Metadata.GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()?.ActionName ?? "Unknown";
                var startTime = DateTime.UtcNow;
                await next.Invoke();
                var endTime = DateTime.UtcNow;
                var duration = endTime - startTime;
                Console.WriteLine($"Finished execution of {actionName}: Execution time: {duration.TotalMilliseconds} ms");
            });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();//זה בשביל הטוקן
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
