using Microsoft.EntityFrameworkCore;
using Repository.Models.DomainModels;
using System;

namespace Repository.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Person> person { get; set; }
       
    }
}
