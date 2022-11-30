using WindowsTrayItemFramework.Data;
using WindowsTrayItemFramework.Helpers;
using WindowsTrayItemFramework.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsTrayItemFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITrayWindow
    {
        private bool _isActive = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task SwitchView(TrayWindowSwitchable toElement)
        {
            await FadeHelper.FadeOut(this, 0.1, 10);
            MainPanel.Children.Clear();
            MainPanel.Children.Add(toElement.Element);
            Width = toElement.TWidth;
            Height = toElement.THeight;
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width - 10;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 45;
            await FadeHelper.FadeIn(this, 0.1, 10, 0.8);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Drawing.Icon icnTask;
            Stream st;
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            st = a.GetManifestResourceStream("WindowsTrayItemFramework.icon.ico");
            NotifyIcon.Icon = new System.Drawing.Icon(st);

            Visibility = Visibility.Hidden;
            await SwitchView(new MainView(this));
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
            NotifyIcon.ContextMenu.IsOpen = true;
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
