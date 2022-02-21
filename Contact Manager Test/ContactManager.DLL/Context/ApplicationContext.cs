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
                    new Person { Id = 1, Name = "Test1", DateOfBirth = new DateTime(2000,1,11), IsMarried = false, Phone = "095", Salary = 23 },
                    new Person { Id = 2, Name = "As", DateOfBirth = new DateTime(1989,1,22), IsMarried = true, Phone = "063", Salary = 12 },
                    new Person { Id = 3, Name = "Res", DateOfBirth = new DateTime(1949,4,2), IsMarried = true, Phone = "068", Salary = 514 },
                    new Person { Id = 4, Name = "Deb", DateOfBirth = new DateTime(1689,6,2), IsMarried = false, Phone = "078", Salary = 7500 },
                    new Person { Id = 5, Name = "Ah", DateOfBirth = new DateTime(1459,8,2), IsMarried = false, Phone = "075", Salary = 7895 },
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
