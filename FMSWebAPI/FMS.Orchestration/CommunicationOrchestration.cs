using FMS.Data.Repository;
using FMS.Helper;
using FMS.Orchestration.Interface;
using FMS.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Orchestration
{
    public class CommunicationOrchestration : ICommunicationOrchestration
    {
        IFileRepository _fileRepository;
        public CommunicationOrchestration(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public int SendMail(FeedbackMailRequest request)
        {
            var attendedParticipants = (from vd in _fileRepository.HackFSE_FMSContext.EventVolunteerDetails.Where(x => !x.IsMailSend && x.ParticipationStatusId == (int)InputFileType.OutReachEventInformation)
                                        join e in _fileRepository.HackFSE_FMSContext.OutreachEvent on vd.EventId equals e.EventId
                                        select new {

                                            EventId = e.EventId,
                                            BaseLocation = e.BaseLocation,
                                            BeneficiaryName = e.BeneficiaryName,
                                            EventName =e.EventName,
                                            EventDate = e.EventDate,
                                            CouncilName = e.CouncilName,
                                            EventDescription = e.EventDescription,
                                            EmployeeId = vd.EmployeeId,
                                            EmployeeName = vd.EmployeeName,
                                            BusinessUnit = vd.BusinessUnit,
                                            EmployeeContactNumber = vd.EmployeeContactNumber,                                                                                        
                                            MailSendCount = vd.MailSendCount,                                                                                        
                                            Status = vd.Status ,
                                            VolunteerHours = vd.VolunteerHours,
                                            TravelHours = vd.TravelHours

                                        }).ToList();




                return 1;
        }
    }
}
