using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BackupManager3
{
    public interface ITrayWindow
    {
        public Task SwitchView(TrayWindowSwitchable toElement);
    }
}
