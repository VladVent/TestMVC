using ContactManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Person>()
                .HasData(new List<Person>
                {
                    new Person { Id = 1, Name = "Test1", DateOfBirth = new DateTime(2000,1,11), IsMarried = false, Phone = "-33423532432423", Salary = 23 },
                    new Person { Id = 2, Name = "Asb", DateOfBirth = new DateTime(1999,1,22), IsMarried = true, Phone = "-12343253", Salary = 12 },
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
