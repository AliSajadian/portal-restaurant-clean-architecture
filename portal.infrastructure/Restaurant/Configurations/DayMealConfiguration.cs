namespace Portal.Infrastructure.Restaurant.Configurations;

using Domain.Restaurant.Models.DayMeals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// using static Domain.Restaurant.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class DayMealConfiguration : IEntityTypeConfiguration<DayMeal>
{
    public void Configure(EntityTypeBuilder<DayMeal> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Date)
            .IsRequired();

        builder
            .Property(a => a.TotalNo);

        builder
            .Property(a => a.IsActive);

        builder
            .HasOne(b => b.Meal)
            .WithMany()
            .HasForeignKey("MealId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}