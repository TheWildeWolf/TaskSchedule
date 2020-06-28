using Microsoft.EntityFrameworkCore;
using Core;
using System;
using Core.Entities;
using Data.Config;

namespace Data
{
    public class SchedulerDbContext : DbContext
    {
        public SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppoinmentConfig());
            builder.ApplyConfiguration(new PassengerConfig());

        }
    }
}
