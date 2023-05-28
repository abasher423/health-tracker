using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.EntityConfigurations;

public class UserEntityBuilder : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");
        builder.HasKey(x => x.Id).HasName("pk_user_id");

        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.Email).IsRequired().HasColumnName("email");
        builder.Property(x => x.Password).IsRequired().HasColumnName("password");
        builder.Property(x => x.FirstName).IsRequired().HasColumnName("first_name");
        builder.Property(x => x.LastName).IsRequired().HasColumnName("last_name");
        
        builder.HasOne<UserProfile>(u => u.UserProfile)
            .WithOne(up => up.User)
            .HasForeignKey<UserProfile>(up => up.UserId)
            .HasConstraintName("fk_user_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}