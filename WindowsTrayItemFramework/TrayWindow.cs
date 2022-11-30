using WindowsTrayItemFramework.Helpers;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace WindowsTrayItemFramework
{
    public class TrayWindow : Window, ITrayWindow
    {
        private bool _isActive = false;
        private TrayWindowSwitchable _currentWindow;
        private System.Drawing.Icon _icon;
        private Grid _mainGrid;
        private TaskbarIcon _notifyIcon;

        public TrayWindow(string title, System.Drawing.Icon icon, TrayWindowSwitchable initialWindow)
        {
            _mainGrid = new Grid();
            this.AddChild(_mainGrid);
            _notifyIcon = new TaskbarIcon()
            {
                Visibility = Visibility.Visible,
                ToolTipText = title,
                PopupActivation = PopupActivationMode.All
            };
            _notifyIcon.TrayMouseDoubleClick += NotifyIcon_TrayMouseDoubleClick;
            _notifyIcon.TrayRightMouseDown += NotifyIcon_TrayRightMouseDown;
            _notifyIcon.ContextMenu = new ContextMenu()
            {
                IsOpen = false
            };
            var exitItem = new MenuItem()
            {
                Header = "Exit"
            };
            exitItem.Click += ExitButton_Click;
            _notifyIcon.ContextMenu.Items.Add(exitItem);

            _mainGrid.Children.Add(_notifyIcon);

            this.Loaded += Window_Loaded;
            this.Deactivated += Window_Deactivated;
            this.Activated += Window_Activated;

            _currentWindow = initialWindow;
            _icon = icon;
            new ViewSwitcher(this);
        }

        public async Task SwitchView(TrayWindowSwitchable toElement)
        {
            await FadeHelper.FadeOut(this, 0.1, 10);
            _mainGrid.Children.Clear();
            _mainGrid.Children.Add(toElement.Element);
            Width = toElement.TargetWidth;
            Height = toElement.TargetHeight;
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width - 10;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 45;
            await FadeHelper.FadeIn(this, 0.1, 10, 0.8);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _notifyIcon.Icon = _icon;
            Visibility = Visibility.Hidden;
            await SwitchView(_currentWindow);
        }

        private async void Window_Deactivated(object sender, EventArgs e)
        {
            _isActive = false;
            for (int i = 0; i < 500; i += 100)
            {
                await Task.Delay(100);
                if (_isActive)
                    break;
            }
            if (!_isActive)
            {
                await FadeHelper.FadeOut(this, 0.02, 10);
                Visibility = Visibility.Hidden;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            _isActive = true;
        }

        private void NotifyIcon_TrayRightMouseDown(object sender, RoutedEventArgs e)
        {
            _notifyIcon.ContextMenu.IsOpen = true;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void NotifyIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Visible;
            await FadeHelper.FadeIn(this, 0.02, 10, 0.8);
            Activate();
        }
    }
}
