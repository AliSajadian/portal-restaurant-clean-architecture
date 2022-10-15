namespace Portal.Infrastructure.Restaurant.Configurations;

using Domain.Restaurant.Models.GuestDayMeals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// using static Domain.Restaurant.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class GuestDayMealConfiguration : IEntityTypeConfiguration<GuestDayMeal>
{
    public void Configure(EntityTypeBuilder<GuestDayMeal> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Date)
            .IsRequired();

        builder
            .Property(a => a.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired();

        builder
            .HasOne(b => b.Department)
            .WithMany()
            .HasForeignKey("DepartmentId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.Project)
            .WithMany()
            .HasForeignKey("ProjectId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}