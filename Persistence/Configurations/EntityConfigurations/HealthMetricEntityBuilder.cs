using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.EntityConfigurations;

public class HealthMetricEntityBuilder : IEntityTypeConfiguration<HealthMetric>
{
    public void Configure(EntityTypeBuilder<HealthMetric> builder)
    {
        builder.ToTable("health_metric");
        builder.HasKey(x => x.Id).HasName("pk_health_metric_id");

        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.Type).IsRequired().HasColumnName("type");
        builder.Property(x => x.UnitOfMeasurement).IsRequired().HasColumnName("unit_of_measurement");

        // configure one to many relationship using FluentAPI (configured on the "one" side of the relationship)
        builder.HasMany<HealthDataEntry>(hm => hm.HealthDataEntries)
            .WithOne(hde => hde.HealthMetric)
            .HasForeignKey(hde => hde.HealthMetricId)
            .HasConstraintName("fk_health_metric_id");
    }
}