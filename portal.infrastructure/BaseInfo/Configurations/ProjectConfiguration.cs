namespace Portal.Infrastructure.BaseInfo.Configurations;

using Domain.BaseInfo.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Name)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .HasOne(b => b.Company)
            .WithMany()
            .HasForeignKey("CompanyId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}