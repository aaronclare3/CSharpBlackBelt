using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;

namespace Belt_exam.Models
{
    public class BeltContext : DbContext
    {
        public BeltContext(DbContextOptions options) : base(options) { }
        public DbSet<User> users {get;set;}
        public DbSet<Act> activities {get;set;}
        public DbSet<Attending> attendees {get;set;}
    }
}