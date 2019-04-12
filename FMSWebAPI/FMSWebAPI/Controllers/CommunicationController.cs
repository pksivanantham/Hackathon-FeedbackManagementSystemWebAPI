using FMS.Orchestration.Interface;
using FMS.ServiceClient;
using Microsoft.AspNetCore.Mvc;

namespace FMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        ICommunicationOrchestration _communicationOrchestration;
        public CommunicationController(ICommunicationOrchestration communicationOrchestration)
        {
            _communicationOrchestration = communicationOrchestration;
        }
        [HttpGet("SendMail")]
        public int SendFeedBackMail(FeedbackMailRequest request)
        {
            

            return 1;
        }
    }
}