using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTrayItemFramework
{
    public class ViewSwitcher
    {
        private static ITrayWindow? _instance;
        public ViewSwitcher(ITrayWindow instance)
        {
            _instance = instance;
        }

        public static async Task SwitchView(TrayWindowSwitchable toElement)
        {
            if (_instance == null)
                throw new ArgumentNullException("Error! Instance was not set!");
            await _instance.SwitchView(toElement);
        }
    }
}
