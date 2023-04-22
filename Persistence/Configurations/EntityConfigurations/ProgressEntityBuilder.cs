using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.EntityConfigurations;

public class ProgressEntityBuilder : IEntityTypeConfiguration<Progress>
{
    public void Configure(EntityTypeBuilder<Progress> builder)
    {
        builder.ToTable("progress");
        builder.HasKey(x => x.Id).HasName("pk_progress_id");

        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.Value).IsRequired().HasColumnName("value");
    }
}