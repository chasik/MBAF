using DevExpress.Xpf.Core;
using System.Windows;

namespace mba_application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DXSplashScreen.Show<SplashScreenView>();
            ApplicationThemeHelper.UpdateApplicationThemeName();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            ApplicationThemeHelper.SaveApplicationThemeName();
        }

        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {

            ApplicationThemeHelper.UpdateApplicationThemeName();
        }
    }
}
