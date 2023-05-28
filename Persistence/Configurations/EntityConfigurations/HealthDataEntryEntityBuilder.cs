using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.EntityConfigurations;

public class HealthDataEntryEntityBuilder : IEntityTypeConfiguration<HealthDataEntry>
{
    public void Configure(EntityTypeBuilder<HealthDataEntry> builder)
    {
        builder.ToTable("health_data_entry");
        builder.HasKey(x => x.Id).HasName("pk_health_data_entry_id");

        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.Name).IsRequired().HasColumnName("name");
        builder.Property(x => x.Value).IsRequired().HasColumnName("value");

        builder.HasOne<User>(hde => hde.User)
            .WithMany(u => u.HealthDataEntries)
            .HasForeignKey(hde => hde.UserId)
            .HasConstraintName("fk_user_id");
    }
}