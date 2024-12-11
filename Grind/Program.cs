using Grind.Core.Interfaces;
using Grind.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Grind.Service;
using Grind.Data;

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


            var app = builder.Build();

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
