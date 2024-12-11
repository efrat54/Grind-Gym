
using Grind.Core.Entities;
using Grind.Core.Enums;
using Grind.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grind.Data
{
    public class DataContext:DbContext/*:IDataContext*/
    {
        public /*static*/DbSet<Class> ClassLst { get; set; }
        public /*static*/ DbSet<Trainer> TrainersLst { get; set; }
        public /*static*/ DbSet<Client>ClientsLst { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_teacher_db");
        }
    }
}
