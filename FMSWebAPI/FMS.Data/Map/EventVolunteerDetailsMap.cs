using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FMSWebAPI.Data
{
    public partial class EventVolunteerDetailsMap : IEntityTypeConfiguration<EventVolunteerDetails>
    {        

        public void Configure(EntityTypeBuilder<EventVolunteerDetails> builder)
        {
            builder.HasIndex(e => e.EmployeeId)
                   .HasName("IX_EventEmployeeDetails_EmployeeID");

            builder.HasIndex(e => e.EventId)
                .HasName("IX_EventEmployeeDetails_EventID");

            builder.HasIndex(e => e.ParticipationStatusId)
                .HasName("IX_EventEmployeeDetails_ParticipationStatusID");

            builder.Property(e => e.EventVolunteerDetailsId)
                .HasColumnName("EventVolunteerDetailsID");
                //.ValueGeneratedNever();

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            builder.Property(e => e.EmployeeName).HasColumnName("EmployeeName");

            builder.Property(e => e.BusinessUnit).HasColumnName("BusinessUnit");

            builder.Property(e => e.EmployeeContactNumber).HasColumnName("EmployeeContactNumber");
            builder.Property(e => e.EventId)
                .IsRequired()
                .HasColumnName("EventID")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.ParticipationStatusId).HasColumnName("ParticipationStatusID");

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.TravelHours).HasColumnType("decimal(18, 0)");

            builder.Property(e => e.VolunteerHours).HasColumnType("decimal(18, 0)");            

            builder.HasOne(d => d.Event)
                .WithMany(p => p.EventVolunteerDetails)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventEmployeeDetails_OutreachEvent");

            builder.HasOne(d => d.ParticipationStatus)
                .WithMany(p => p.EventVolunteerDetails)
                .HasForeignKey(d => d.ParticipationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventEmployeeDetails_ParticipationStatus");
        }
    }
}
