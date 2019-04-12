namespace FMS.ServiceClient
{
    public class EventVolunteerDetailsRequest
    {
        public int EventVolunteerDetailsId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string BusinessUnit { get; set; }
        public string EmployeeContactNumber { get; set; }
        public decimal? VolunteerHours { get; set; }
        public decimal? TravelHours { get; set; }
        public string Status { get; set; }
        public bool IsMailSend { get; set; }
        public int MailSendCount { get; set; }
        public int ParticipationStatusId { get; set; }

        public OutreachEventRequest Event { get; set; }


    }
}