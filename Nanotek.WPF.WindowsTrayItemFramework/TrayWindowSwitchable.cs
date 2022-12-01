using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nanotek.WPF.WindowsTrayItemFramework
{
    public interface TrayWindowSwitchable
    {
        public UIElement Element { get; }
        public double TargetWidth { get; }
        public double TargetHeight { get; }
    }
}
