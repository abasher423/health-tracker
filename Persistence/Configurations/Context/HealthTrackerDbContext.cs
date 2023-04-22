using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Configurations.EntityConfigurations;

namespace Persistence.Configurations.Context;

public class HealthTrackerDbContext : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }
    
    public DbSet<HealthMetric> HealthMetrics { get; set; }
    
    public DbSet<HealthDataEntry> HealthDataEntries { get; set; }
    
    public DbSet<Goal> Goals { get; set; }
    
    public DbSet<Progress> Progresses { get; set; }
    
    public HealthTrackerDbContext(DbContextOptions<HealthTrackerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("health");

        var userProfileConfiguration = new UserProfileEntityBuilder();
        var healthMetricConfiguration = new HealthMetricEntityBuilder();
        var healthDataEntryConfiguration = new HealthDataEntryEntityBuilder();
        var goalConfiguration = new GoalEntityBuilder();
        var progressConfiguration = new ProgressEntityBuilder();
        
        userProfileConfiguration.Configure(modelBuilder.Entity<UserProfile>());
        healthMetricConfiguration.Configure(modelBuilder.Entity<HealthMetric>());
        healthDataEntryConfiguration.Configure(modelBuilder.Entity<HealthDataEntry>());
        goalConfiguration.Configure(modelBuilder.Entity<Goal>());
        progressConfiguration.Configure(modelBuilder.Entity<Progress>());
    }
}