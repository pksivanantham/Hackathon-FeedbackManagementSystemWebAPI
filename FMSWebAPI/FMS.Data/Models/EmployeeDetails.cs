using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class EmployeeDetails
    {
        public EmployeeDetails()
        {
            EventPocdetails = new HashSet<EventPocdetails>();
            EventVolunteerDetails = new HashSet<EventVolunteerDetails>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string BusinessUnit { get; set; }
        public string EmployeeContactNumber { get; set; }

        public ICollection<EventPocdetails> EventPocdetails { get; set; }
        public ICollection<EventVolunteerDetails> EventVolunteerDetails { get; set; }
    }
}
