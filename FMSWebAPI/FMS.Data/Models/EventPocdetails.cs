using System;
using System.Collections.Generic;

namespace FMSWebAPI.Data
{
    public partial class EventPocdetails
    {
        public int EventPocdetailsId { get; set; }
        public string EventId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }        
        public string EmployeeContactNumber { get; set; }
        public OutreachEvent Event { get; set; }
    }
}
