using FMS.Data.Repository;
using FMS.ServiceClient;
using FMSWebAPI.Data;
using System.Collections.Generic;
using System.Linq;
namespace FMS.Orchestration
{
    public class FileProcessOrchestration
    {
        public FileProcessOrchestration()
        {

        }

        public int SaveFile(FileProcessRequest request)
        {            
           return  SaveFileContent(request);
        }

        private int SaveFileContent(FileProcessRequest request)
        {
            var result = 1;            

            var eventList = new List<EventVolunteerDetails>();

            foreach (var item in request.EventVolunteerDetails)//todo:i think this can be minimized with automapper
            {

                var outreachEvent = new OutreachEvent()
                {

                    EventId = item.EventId,
                    BaseLocation = item.Event.BaseLocation,
                    BeneficiaryName = item.Event.BeneficiaryName,
                    EventName = item.Event.EventName,
                    EventDate = item.Event.EventDate,
                    CouncilName = item.Event.CouncilName,
                    EventDescription =item.Event.EventDescription

                };              
                var eventVolunteerDetails = new EventVolunteerDetails()
                {
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    BusinessUnit = item.BusinessUnit,
                    EmployeeContactNumber = item.EmployeeContactNumber,                    
                    Event = outreachEvent,
                    IsMailSend = false,
                    MailSendCount = 0,
                    ParticipationStatusId = item.ParticipationStatusId,                    
                    EventId = outreachEvent.EventId,
                    Status = item.Status??"",
                    VolunteerHours=item.VolunteerHours,
                    TravelHours=item.TravelHours

                };
                eventList.Add(eventVolunteerDetails);
            }

            var eventInformation = eventList.GroupBy(x => x.EventId).Select(x => x.FirstOrDefault()?.Event).ToList();

            var fileRepository = new FileRepository();

            fileRepository.SaveOutReachEvents(eventInformation);

            fileRepository.SaveEventVolunteerDetails(eventList);

            return result;
        }        

    }
}
