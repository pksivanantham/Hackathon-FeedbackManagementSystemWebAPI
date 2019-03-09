using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class OutreachEventMap : IEntityTypeConfiguration<OutreachEvent>
    {
        public void Configure(EntityTypeBuilder<OutreachEvent> builder)
        {
            builder.HasKey(e => e.EventId);

            builder.Property(e => e.EventId)
                .HasColumnName("EventID")
                .HasMaxLength(10)
                .IsUnicode(false)
                .ValueGeneratedNever();

            builder.Property(e => e.BaseLocation)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.BeneficiaryAddress)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.BeneficiaryName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CouncilName)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.EventDate).HasColumnType("datetime");

            builder.Property(e => e.EventDescription)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.EventName)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.LivesImpacted).HasColumnType("decimal(18, 0)");

            builder.Property(e => e.ProjectName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
