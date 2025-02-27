﻿
using Grind.Core.Entities;
using Grind.Core.Enums;
using Grind.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Grind.Data
{
    public class DataContext:DbContext/*:IDataContext*/
    {
        public DbSet<Class> ClassLst { get; set; }
        public  DbSet<Trainer> TrainersLst { get; set; }
        public  DbSet<Client>ClientsLst { get; set; }
        public DbSet<Time> TimesLst { get; set; }
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);
            //optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_teacher_db").LogTo(Console.WriteLine,LogLevel.Information);

        }
    }
}
