using Domain;
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

        var userConfiguration = new UserEntityBuilder();
        var userProfileConfiguration = new UserProfileEntityBuilder();
        var healthMetricConfiguration = new HealthMetricEntityBuilder();
        var healthDataEntryConfiguration = new HealthDataEntryEntityBuilder();
        var goalConfiguration = new GoalEntityBuilder();
        var progressConfiguration = new ProgressEntityBuilder();
        
        userConfiguration.Configure(modelBuilder.Entity<User>());
        userProfileConfiguration.Configure(modelBuilder.Entity<UserProfile>());
        healthMetricConfiguration.Configure(modelBuilder.Entity<HealthMetric>());
        healthDataEntryConfiguration.Configure(modelBuilder.Entity<HealthDataEntry>());
        goalConfiguration.Configure(modelBuilder.Entity<Goal>());
        progressConfiguration.Configure(modelBuilder.Entity<Progress>());
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is TableAudit && (
                e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).Modified = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).Added = DateTime.UtcNow;
                ((BaseEntity)entityEntry.Entity).Modified = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}