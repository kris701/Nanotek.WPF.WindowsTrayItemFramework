using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemplateProject
{
    public partial class MainWindow : TrayWindow
    {
        public MainWindow() : base("Tray Icon Title", GetEmbeddedIcon(), new TemplateView())
        {
            InitializeComponent();
        }

        private static System.Drawing.Icon GetEmbeddedIcon()
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            var st = a.GetManifestResourceStream("TemplateProject.icon.ico");
            if (st == null)
                throw new FileNotFoundException("Error! Icon file not found!");
            return new System.Drawing.Icon(st);
        }
    }
}
