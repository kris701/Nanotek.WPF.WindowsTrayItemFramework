﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WindowsTrayItemFramework.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, TrayWindowSwitchable
    {
        private ITrayWindow _trayWindow;

        public UIElement Element { get; }
        public double TWidth { get; } = 800;
        public double THeight { get; } = 450;

        public MainView(ITrayWindow trayWindow)
        {
            InitializeComponent();
            _trayWindow = trayWindow;
            Element = this;
        }
    }
}