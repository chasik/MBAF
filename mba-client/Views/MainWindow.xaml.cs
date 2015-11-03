using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using pjsip4net.Configuration;
using pjsip4net.Core.Configuration;
using pjsip4net.Interfaces;

using mba_client.components;

namespace mba_client
{
    public partial class MainWindow : DevExpress.Xpf.Core.DXWindow
    {
        //private ISipUserAgent ua;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DXWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var cfg = Configure.Pjsip4Net().FromConfig();//read configuration from .config file 
            //ua = cfg.Build().Start();//build and start
            //ua.CallManager.MakeCall("sip:117@aster.mbaru.ru:5060");
        }
    }
}
