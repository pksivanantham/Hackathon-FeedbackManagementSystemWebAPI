using System;
using System.Collections.Generic;

namespace FMSWebAPI.Models
{
    public partial class EventPocdetails
    {
        public int EventPocdetailsId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }

        public EmployeeDetails Employee { get; set; }
        public OutreachEvent Event { get; set; }
    }
}
