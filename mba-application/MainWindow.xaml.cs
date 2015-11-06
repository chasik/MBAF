using System.Windows;
using DevExpress.Xpf.Core;

namespace mba_application
{
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            var p = new PermissionsService.PermissionsServiceClient();
            var z = p.GetPermission();

            var k = z.UserName;

        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            DXSplashScreen.Close();
        }
    }
}
