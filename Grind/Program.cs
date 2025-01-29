using Grind.Core.Interfaces;
using Grind.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Grind.Service;
using Grind.Data;
using Grind.Core.Dots;

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
            builder.Services.AddSwaggerGen();

            //הזרקת תלויות
            //builder.Services.AddSingleton<IDataContext,DataContext>();
            builder.Services.AddDbContext<DataContext>();           
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));

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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
