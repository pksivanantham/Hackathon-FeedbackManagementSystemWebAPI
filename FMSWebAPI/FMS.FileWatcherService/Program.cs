using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FMS.FileWatcherService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FileWatcherService()
            };
#if DEBUG            
            FileWatcherService fileWatcherService = new FileWatcherService();
            fileWatcherService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);


#else
            ServiceBase.Run(ServicesToRun);
#endif
            
        }
    }
}
