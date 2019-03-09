using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class EventVolunteerDetails
    {
        public int EventVolunteerDetailsId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public decimal? VolunteerHours { get; set; }
        public decimal? TravelHours { get; set; }
        public string Status { get; set; }
        public bool IsMailSend { get; set; }
        public int MailSendCount { get; set; }
        public int ParticipationStatusId { get; set; }

        public EmployeeDetails Employee { get; set; }
        public OutreachEvent Event { get; set; }
        public ParticipationStatus ParticipationStatus { get; set; }
    }
}
