using System.Threading;
using System.Windows;

namespace BookStore.Viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            IsAlreadyRunning();

            base.OnStartup(e);

            Bootstraper bs = new Bootstraper();
            bs.Run();
        }

        public static void IsAlreadyRunning()
        {
            const string appName = "MyAppName";
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                Application.Current.Shutdown();
            }
        }
    }
}
