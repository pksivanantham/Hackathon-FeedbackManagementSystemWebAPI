using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FMS.FileWatcherService
{
    [RunInstaller(true)]
    public partial class FileWatcherInstaller : System.Configuration.Install.Installer
    {
        private readonly ServiceProcessInstaller serviceProcessInstaller;
        private readonly ServiceInstaller serviceInstaller;
        public FileWatcherInstaller()
        {

            InitializeComponent();
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();

            // Service will run under system account
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;

            // Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.ServiceName = "FMS FileWatcher Service";

            Installers.Add(serviceInstaller);
            Installers.Add(serviceProcessInstaller);
            serviceInstaller.AfterInstall += ServiceInstaller_AfterInstall;

        }

        private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            ServiceController serviceController = new ServiceController("FMS FileWatcher Service");
            serviceController.Start();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
    }
}
