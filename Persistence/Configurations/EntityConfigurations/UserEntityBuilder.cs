using Common.Enums;
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

        builder.Property(x => x.Email).IsRequired().HasColumnName("email").HasMaxLength(32)
            .HasAnnotation("RegularExpression",
                @"(?:[a-z0-9!#$%&'*+/?=^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/?=^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\]");
        builder.HasIndex(x => x.Email).IsUnique();
        
        builder.Property(x => x.EmailConfirmed).HasColumnName("email_confirmed")
            .IsRequired().HasDefaultValue(false);
        
        builder.Property(x => x.EmailVerificationToken).HasColumnName("email_verification_token")
            .HasMaxLength(100).IsRequired();
        
        builder.Property(x => x.EmailVerificationTokenExpiration)
            .HasColumnName("email_verification_token_expiration");

        builder.Property(x => x.EmailTokenStatus).IsRequired()
            .HasColumnName("email_token_status").IsRequired()
            .HasConversion(v => v.ToString(), // Convert enum to string for storage
                v => (TokenStatus)Enum.Parse(typeof(TokenStatus), v) // Convert string to enum when reading from the database
            ).HasMaxLength(20);
        
        builder.Property(x => x.HashedPassword).HasColumnName("password")
            .IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.FirstName).HasColumnName("first_name")
            .IsRequired().HasMaxLength(50);
        
        builder.Property(x => x.LastName).HasColumnName("last_name")
            .IsRequired().HasMaxLength(50);
        
        builder.HasOne<UserProfile>(u => u.UserProfile)
            .WithOne(up => up.User)
            .HasForeignKey<UserProfile>(up => up.UserId)
            .HasConstraintName("fk_user_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}