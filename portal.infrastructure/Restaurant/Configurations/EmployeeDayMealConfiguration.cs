namespace Portal.Infrastructure.Restaurant.Configurations;

using Domain.Restaurant.Models.EmployeeDayMeals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class EmployeeDayMealConfiguration : IEntityTypeConfiguration<EmployeeDayMeal>
{
    public void Configure(EntityTypeBuilder<EmployeeDayMeal> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Served)
            .IsRequired();

        builder
            .HasOne(b => b.Employee)
            .WithMany()
            .HasForeignKey("EmployeeId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.DayMeal)
            .WithMany()
            .HasForeignKey("DayMealId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}