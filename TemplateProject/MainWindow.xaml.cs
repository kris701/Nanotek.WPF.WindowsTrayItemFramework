using WindowsTrayItemFramework;
using System;
using System.IO;

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
