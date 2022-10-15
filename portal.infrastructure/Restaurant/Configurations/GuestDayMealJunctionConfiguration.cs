namespace Portal.Infrastructure.Restaurant.Configurations;

using Domain.Restaurant.Models.GuestDayMealJunctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class GuestDayMealJunctionConfiguration : IEntityTypeConfiguration<GuestDayMealJunction>
{
    public void Configure(EntityTypeBuilder<GuestDayMealJunction> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Qty)
            .IsRequired();

        builder
            .HasOne(b => b.DayMeal)
            .WithMany()
            .HasForeignKey("DayMealId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(b => b.GuestDayMeal)
            .WithMany()
            .HasForeignKey("GuestDayMealId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}