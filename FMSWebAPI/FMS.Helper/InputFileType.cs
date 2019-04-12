using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Helper
{
    public enum InputFileType
    {
        [Description("OutReach Event Information")]
        OutReachEventInformation =1 ,
        [Description("Volunteer_Enrollment Details_Not_Attend")]
        VolunteerEnrollmentDetailsNotAttend = 2,        
        [Description("Volunteer_Enrollment Details_Unregistered")]
        VolunteerEnrollmentDetailsUnregistered =3,
        [Description("Outreach Events Summary")]
        OutreachEventsSummary = 4

    }


}
