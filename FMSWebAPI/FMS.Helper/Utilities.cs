using System.Collections.Generic;
using System.Linq;

namespace FMS.Helper
{
    public static class Utilities
    {

        public static Dictionary<string,InputFileType> GetPredefinedFileNames()
        {
            var dictionary = new Dictionary<string, InputFileType>();

            dictionary.Add("OutReach Event Information",InputFileType.OutReachEventInformation);
            dictionary.Add("Volunteer_Enrollment Details_Not_Attend", InputFileType.VolunteerEnrollmentDetailsNotAttend);
            dictionary.Add("Volunteer_Enrollment Details_Unregistered", InputFileType.VolunteerEnrollmentDetailsUnregistered);
            dictionary.Add("Outreach Events Summary", InputFileType.OutreachEventsSummary);

            return dictionary;

        }

        public static InputFileType  GetInputFileType(string key)
        {
            return GetPredefinedFileNames()[key];

        }

    }

    public enum ParticipationStatus
    {
        Participated = 1,
        DidNotParticipate = 2,
        Unregistered = 3
    }

}
