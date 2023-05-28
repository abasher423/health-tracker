using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.EntityConfigurations;

public class GoalEntityBuilder : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.ToTable("goal");
        builder.HasKey(x => x.Id).HasName("pk_goal_id");

        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.Name).IsRequired().HasColumnName("name");
        builder.Property(x => x.Target).IsRequired().HasColumnName("target");

        builder.HasOne<User>(g => g.User)
            .WithMany(u => u.Goals)
            .HasForeignKey(g => g.UserId)
            .HasConstraintName("fk_user_id");
    }
}