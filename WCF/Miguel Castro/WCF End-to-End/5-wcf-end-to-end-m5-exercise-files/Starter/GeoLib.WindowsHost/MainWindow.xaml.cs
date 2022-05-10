using GeoLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace GeoLib.WindowsHost
{
    public partial class MainWindow : Window
    {
        public static MainWindow MainUI { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            MainUI = this;

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId + 
                " | Process " + Process.GetCurrentProcess().Id.ToString();
        }

        ServiceHost _HostGeoManager = null;

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _HostGeoManager = new ServiceHost(typeof(GeoManager));
            _HostGeoManager.Open();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _HostGeoManager.Close();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        public void ShowMessage(string message)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            lblMessage.Content = message + Environment.NewLine + " (shown on thread " + threadId.ToString() +
                " | Process " + Process.GetCurrentProcess().Id.ToString() + ")";
        }
    }
}
