namespace Portal.Infrastructure.BaseInfo.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Restaurant.Models.Meals;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();
    }
}