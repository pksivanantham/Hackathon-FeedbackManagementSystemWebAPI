using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class ParticipationStatusMap : IEntityTypeConfiguration<ParticipationStatus>
    {
        public void Configure(EntityTypeBuilder<ParticipationStatus> builder)
        {
            builder.Property(e => e.ParticipationStatusId)
                   .HasColumnName("ParticipationStatusID")
                   .ValueGeneratedNever();

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ParticipationStatus1)
                .IsRequired()
                .HasColumnName("ParticipationStatus")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
