using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    internal class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-QB15QEM\\MSSQLSERVER01;Database=TodoApp;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Todo>().HasData(
        //        new Todo
        //        {
        //            Id = 1,
        //            Title = "Jogging",
        //            Description = "Run through the field",
        //            CreatedDate = DateTime.Now,
        //        },
        //        new Todo
        //        {
        //            Id= 2,
        //            Title = "Cleaning",
        //            Description = "Clean the entire house",
        //            CreatedDate = DateTime.Now,
        //        }
        //    );
        //}
    }
}
