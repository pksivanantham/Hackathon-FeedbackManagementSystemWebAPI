using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FMS.FileWatcherService
{
    public partial class FileWatcherService : ServiceBase
    {
        FileWatcher fileWatcher;
        public FileWatcherService()
        {
            InitializeComponent();
        }
        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            fileWatcher = new FileWatcher(@"C:\Users\Administrator\Documents\TEST-FTP-PATH\\");

            fileWatcher.Start();
        }

        protected override void OnStop()
        {
            fileWatcher = null;
        }
    }
}
