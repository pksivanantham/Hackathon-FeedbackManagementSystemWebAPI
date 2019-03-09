using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FMSWebAPI.Models
{
    public partial class HackFSE_FMSContext : DbContext
    {
        public HackFSE_FMSContext()
        {
        }

        public HackFSE_FMSContext(DbContextOptions<HackFSE_FMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EventPocdetails> EventPocdetails { get; set; }
        public virtual DbSet<EventVolunteerDetails> EventVolunteerDetails { get; set; }
        public virtual DbSet<OutreachEvent> OutreachEvent { get; set; }
        public virtual DbSet<ParticipationStatus> ParticipationStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("SERVER=DOTNET;Database=HackFSE_FMS;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new EmployeeDetailsMap());
            modelBuilder.ApplyConfiguration(new EventPocdetailsMap());
            modelBuilder.ApplyConfiguration(new EventVolunteerDetailsMap());
            modelBuilder.ApplyConfiguration(new OutreachEventMap());
            modelBuilder.ApplyConfiguration(new ParticipationStatusMap());

            //modelBuilder.Entity<EventVolunteerDetails>(builder =>
            //{

            //});

           
        }
    }
}
