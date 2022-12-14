namespace Portal.Infrastructure.BaseInfo.Configurations;

using Domain.BaseInfo.Models.JobPositions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
{
    public void Configure(EntityTypeBuilder<JobPosition> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();
    }
}