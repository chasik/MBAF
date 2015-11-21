using System.Windows;
using DevExpress.Xpf.Core;
using mba_application.MBAComponents;
using WordsMatching;
using System.Diagnostics;

namespace mba_application
{
    public partial class MainView : DXWindow
    {
        public MainView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            //MatchsMaker match = new MatchsMaker("188660, Ленинградская обл, Всеволожский р-н, Бугры п, ул Шоссейная, д. 30, кв. 25", "187403, Ленинградская обл, г Волхов, ул Ломоносова, д. 22, кв. 87");
            //Trace.WriteLine(match.Score);
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            DXSplashScreen.Close();
        }
    }
}
