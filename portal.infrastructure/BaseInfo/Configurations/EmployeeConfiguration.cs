namespace Portal.Infrastructure.BaseInfo.Configurations;

using Domain.BaseInfo.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// using static Domain.BaseInfo.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Common;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.PersonelCode)
            .IsRequired();

        builder
            .Property(a => a.FirstName)
            .IsRequired();

        builder
            .Property(a => a.LastName)
            .IsRequired();

        builder
            .Property(a => a.Gender)
            .IsRequired();

        builder
            .Property(a => a.Picture);

        builder
            .Property(a => a.Phone);

        builder
            .Property(a => a.Email)
            .IsRequired();

        builder
            .Property(a => a.IsActive);

        builder
            .HasOne(b => b.JobPosition)
            .WithMany()
            .HasForeignKey("JobPositionId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

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

        builder
            .Property(a => a.UserId);
    }
}