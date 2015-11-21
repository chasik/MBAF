using DevExpress.Xpf.Core;
using System.Diagnostics;
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
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
            PresentationTraceSources.DataBindingSource.Listeners.Add(new DebugTraceListener());
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning | SourceLevels.Error;
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

    public class DebugTraceListener : TraceListener
    {
        public override void Write(string message)
        {
        }

        public override void WriteLine(string message)
        {
            //Trace.WriteLine(message);
        }
    }
}
