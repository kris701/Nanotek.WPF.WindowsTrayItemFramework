using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsTrayItemFramework
{
    public interface ITrayWindow
    {
        public Task SwitchView(TrayWindowSwitchable toElement);
    }
}
