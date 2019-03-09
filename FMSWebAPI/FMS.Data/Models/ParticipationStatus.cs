using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class ParticipationStatus
    {
        public ParticipationStatus()
        {
            EventVolunteerDetails = new HashSet<EventVolunteerDetails>();
        }

        public int ParticipationStatusId { get; set; }
        public string ParticipationStatus1 { get; set; }
        public string Description { get; set; }

        public ICollection<EventVolunteerDetails> EventVolunteerDetails { get; set; }
    }
}
