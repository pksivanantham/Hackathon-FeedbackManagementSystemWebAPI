using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMS.Orchestration;
using FMS.ServiceClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        FileProcessOrchestration _fileProcessOrchestration;

        public FileProcessController()
        {
            _fileProcessOrchestration = new FileProcessOrchestration();
        }

        [HttpPost("SaveFileInformation")]
        public int SaveFileInformation(FileProcessRequest request)
        {

            return _fileProcessOrchestration.SaveFile(request);
                        
        }
                
                
    }
}