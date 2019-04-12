using FMSWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Data.Repository
{
    public class FileRepository: IFileRepository
    {
        HackFSE_FMSContext _hackFSE_FMSContext;

        HackFSE_FMSContext IFileRepository.HackFSE_FMSContext { get =>  _hackFSE_FMSContext;  }

        public FileRepository()
        {
            _hackFSE_FMSContext = new HackFSE_FMSContext();
        }
        public void SaveOutReachEvents(List<OutreachEvent> outReachEvents)
        {
            foreach (var eventInfo in outReachEvents)
            {
                if (_hackFSE_FMSContext.OutreachEvent.Find(eventInfo.EventId) == null)
                {
                    _hackFSE_FMSContext.OutreachEvent.Add(eventInfo);
                    _hackFSE_FMSContext.SaveChanges();
                }
            }
        }

        public void SaveEventVolunteerDetails(List<EventVolunteerDetails> eventVolunteerDetails)
        {
            foreach (var eventInfo in eventVolunteerDetails)
            {               
                _hackFSE_FMSContext.EventVolunteerDetails.Add(eventInfo);

                _hackFSE_FMSContext.SaveChanges();
            }
        }
    }
}
