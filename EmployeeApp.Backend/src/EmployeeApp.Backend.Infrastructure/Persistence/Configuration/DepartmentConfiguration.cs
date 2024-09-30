using EmployeeApp.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using static EmployeeApp.Backend.Infrastructure.Persistence.Configuration.DepartmentConfigurationConstants;

namespace EmployeeApp.Backend.Infrastructure.Persistence.Configuration;

[ExcludeFromCodeCoverage]
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(TableName);

        builder.HasKey(p => p.Id)
            .HasName(IdName);

        builder.Property(p => p.Name)
            .HasMaxLength(NameMaxLength);
    }
}

[ExcludeFromCodeCoverage]
public static class DepartmentConfigurationConstants
{
    public const string TableName = "Department";
    public const string IdName = "ID";
    public const int NameMaxLength = 100;
}
