using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.EntityConfigurations;

public class UserProfileEntityBuilder : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("user_profile");
        builder.HasKey(x => x.Id).HasName("pk_user_profile_id");

        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.Age).IsRequired().HasColumnName("age");
        builder.Property(x => x.Gender).IsRequired().HasColumnName("gender");
        builder.Property(x => x.Height).IsRequired().HasColumnName("height");
        builder.Property(x => x.Weight).IsRequired().HasColumnName("weight");
    }
}