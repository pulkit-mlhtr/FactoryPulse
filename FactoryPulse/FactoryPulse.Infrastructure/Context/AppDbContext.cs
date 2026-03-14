using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Infrastructure.Context
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EquipmentStateLog> EquipmentStateLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
