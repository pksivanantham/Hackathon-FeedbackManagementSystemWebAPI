using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.ServiceClient
{
    public class OutreachEventRequest
    {
     
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string BaseLocation { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string CouncilName { get; set; }
        public string ProjectName { get; set; }
        public string Category { get; set; }
        public decimal LivesImpacted { get; set; }

        
    }
}
