using Domain;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces.V1;
using MediatR;
using Persistence.Configurations.EntityConfigurations;

namespace Persistence.Configurations.Context;

public class HealthTrackerDbContext : DbContext
{
    private readonly IMediator _mediator;
    
    public DbSet<User> Users { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }
    
    public DbSet<HealthMetric> HealthMetrics { get; set; }
    
    public DbSet<HealthDataEntry> HealthDataEntries { get; set; }
    
    public DbSet<Goal> Goals { get; set; }
    
    public DbSet<Progress> Progresses { get; set; }
    
    public HealthTrackerDbContext(DbContextOptions<HealthTrackerDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
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
        
        // Dispatch Domain Events collection.
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes
        // a single transaction including side effects from the domain event
        // handlers that are using the same DbContext with Scope lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes
        // multiple transactions. You will need to handle eventual consistency and
        // compensatory actions in case of failures.
        await _mediator.Publish(this, cancellationToken);

        return await base.SaveChangesAsync(cancellationToken);
    }
}