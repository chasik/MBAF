using System.Windows;
using DevExpress.Xpf.Core;

namespace mba_application
{
    public partial class MainView : DXWindow
    {
        public MainView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            var p = new MBAPermissionsService.PermissionsServiceClient();
            var z = p.GetPermissions();

            var k = z.Login;

        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            DXSplashScreen.Close();
        }
    }
}
