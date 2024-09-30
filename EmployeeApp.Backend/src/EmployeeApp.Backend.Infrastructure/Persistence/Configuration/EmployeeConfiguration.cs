using EmployeeApp.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using static EmployeeApp.Backend.Infrastructure.Persistence.Configuration.EmployeeConfigurationConstants;

namespace EmployeeApp.Backend.Infrastructure.Persistence.Configuration;

[ExcludeFromCodeCoverage]
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(p => p.Id)
            .HasName(IdName);

        builder.Property(p => p.DepartmentId)
            .HasColumnName(DepartmentIdName);

        builder.HasOne(p => p.Department)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.DepartmentId);

        builder.Property(p => p.ManagerId)
            .HasColumnName(ManagerIdName);

        builder.HasOne(p => p.Manager)
            .WithMany(p => p.Subordinates)
            .HasForeignKey(p => p.ManagerId);

        builder.Property(p => p.Name)
            .HasMaxLength(NameMaxLength);

        builder.Property(p => p.Salary)
            .HasColumnType(SalaryColumnType);
    }
}

[ExcludeFromCodeCoverage]
public static class EmployeeConfigurationConstants
{
    public const string TableName = "Employee";
    public const string IdName = "ID";
    public const string DepartmentIdName = "DepartmentID";
    public const string ManagerIdName = "ManagerID";
    public const int NameMaxLength = 100;
    public const string SalaryColumnType = "decimal(18, 2)";
}
