using FMSWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Data.Repository
{
    public interface IFileRepository
    {
        HackFSE_FMSContext HackFSE_FMSContext { get;  }
    }
}
