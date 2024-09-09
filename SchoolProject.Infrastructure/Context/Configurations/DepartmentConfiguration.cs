using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Context.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d=>d.DID);
            builder.Property(d => d.DID)
                .ValueGeneratedOnAdd();
            builder.Property(d => d.DName)
                .HasMaxLength(500);
        }
    }
}
