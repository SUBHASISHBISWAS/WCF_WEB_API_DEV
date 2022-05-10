using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;

namespace GeoLib.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {

            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if (txtState.Text != null)
            {
                EndpointAddress address = new EndpointAddress("net.tcp://localhost:8009/GeoService");
                Binding binding = new NetTcpBinding();


            }
        }
    }
}
