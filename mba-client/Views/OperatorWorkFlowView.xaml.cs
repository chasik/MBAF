using mba_client.components;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mba_client.Views
{
    /// <summary>
    /// Interaction logic for OperatorWorkFlowView.xaml
    /// </summary>
    public partial class OperatorWorkFlowView : UserControl
    {
        public OperatorWorkFlowView()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            PhonePjsip4net p = new PhonePjsip4net();
        }
    }
}
