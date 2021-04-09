using CefSharp.Wpf;
using System.Timers;
using System.Windows;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class MainWindow : Window
    {
        private ChromiumWebBrowser browser;

        public MainWindow()
        {
            InitializeComponent();

            var timer = new Timer(5000);
            timer.Elapsed += (object senderCreate, ElapsedEventArgs eCreate) =>
            {
                Create();

                var timerClear = new Timer(2500);
                timerClear.Elapsed += (object senderClear, ElapsedEventArgs eCLear) =>
                {
                    Clear();
                    timerClear.Stop();
                };
                timerClear.Start();
            };
            timer.Start();
        }

        private void Create()
        {
            Dispatcher.Invoke(() =>
            {
                browser = new ChromiumWebBrowser();
                browser.Name = "browser";
                browser.Address = "https://www.heise.de";
                browser.BrowserSettings.WindowlessFrameRate = 60;

                Border.Child = browser;
            });
        }

        private void Clear()
        {
            Dispatcher.Invoke(() =>
            {
                Border.Child = null;

                browser.Dispose();
                browser = null;
            });
        }
    }
}
