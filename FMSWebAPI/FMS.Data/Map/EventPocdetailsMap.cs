using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FMSWebAPI.Data
{
    public partial class EventPocdetailsMap : IEntityTypeConfiguration<EventPocdetails>
    {
        public void Configure(EntityTypeBuilder<EventPocdetails> builder)
        {

            builder.ToTable("EventPOCDetails");

            builder.HasIndex(e => e.EmployeeId);

            builder.HasIndex(e => e.EventId);

            builder.Property(e => e.EventPocdetailsId)
                    .HasColumnName("EventPOCDetailsID");
                   // .ValueGeneratedNever();

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            builder.Property(e => e.EmployeeName).HasColumnName("EmployeeName");

            builder.Property(e => e.EmployeeContactNumber).HasColumnName("EmployeeContactNumber");

            builder.Property(e => e.EventId)
                    .IsRequired()
                    .HasColumnName("EventID")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            

            builder.HasOne(d => d.Event)
                    .WithMany(p => p.EventPocdetails)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPOCDetails_OutreachEvent");
          

        }
    }
}
