using Contact_Manager_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DLL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PersonModel> UserModelDB { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=PersonDb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonModel>()
            .HasKey(x => x.IdPerson);

            base.OnModelCreating(modelBuilder);
        }
    }
}
