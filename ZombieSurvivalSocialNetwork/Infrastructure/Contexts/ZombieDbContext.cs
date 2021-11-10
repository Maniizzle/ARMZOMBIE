using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Core.Domain.Entities;
using ZombieSurvivalSocialNetwork.Infrastructure.Configurations;

namespace ZombieSurvivalSocialNetwork.Infrastructure.Contexts
{
    public class ZombieDbContext:DbContext
    {
        public DbSet<Survivor> Survivors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<SurvivorItem> SurvivorItems  { get; set; }
        public DbSet<SurvivorsTrade> SurvivorsTrades { get; set; }
        public DbSet<SurvivorsRequestAndResponseResource> SurvivorsRequestAndResponseResource { get; set; }
        public DbSet<InfectionReport> InfectionReports { get; set; }

        public ZombieDbContext(DbContextOptions<ZombieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Survivor>().HasIndex(c => c.IsInfected);
            builder.Entity<InfectionReport>().HasKey(c => new { c.ReportedSurvivor, c.ReportingSurvivor });
            builder.Entity<SurvivorItem>().HasKey(c => new { c.ItemId, c.SurvivorId });
            builder.ApplyConfiguration(new SeedItemData());

        }
    }
}
