using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class EmployeeDetailsMap: IEntityTypeConfiguration<EmployeeDetails>
    {
        
        public void Configure(EntityTypeBuilder<EmployeeDetails> builder)
        {

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .ValueGeneratedNever();

            builder.Property(e => e.BusinessUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.EmployeeContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            
        }
    }
}
