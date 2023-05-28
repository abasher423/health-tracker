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

        // configure one to many relationship using FluentAPI (configured on the "many" side of the relationship)
        builder.HasOne<User>(p => p.User)
            .WithMany(u => u.Progresses)
            .HasForeignKey(p => p.UserId)
            .HasConstraintName("fk_user_id");
        
        builder.HasOne<Goal>(p => p.Goal)
            .WithMany(g => g.Progresses)
            .HasForeignKey(p => p.GoalId)
            .HasConstraintName("fk_goal_id");
    }
}