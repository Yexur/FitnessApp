using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class FitnessAppContext : DbContext
    {
        public FitnessAppContext(DbContextOptions<FitnessAppContext> options) : base(options)
        {
      
        }

        public DbSet<FitnessClassType> FitnessClassType { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<FitnessClass> FitnessClass { get; set; }
        public DbSet<RegistrationRecord> RegistrationRecord { get; set; }
    }
}
