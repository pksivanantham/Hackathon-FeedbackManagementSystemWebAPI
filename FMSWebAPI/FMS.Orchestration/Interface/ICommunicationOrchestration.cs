using FMS.ServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Orchestration.Interface
{
    public interface ICommunicationOrchestration
    {

        int SendMail(FeedbackMailRequest request);
    }
}
