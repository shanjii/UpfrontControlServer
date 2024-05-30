using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ICPServer
{

    public partial class MainWindow : Window
    {
        private readonly NotifyIcon ni = new();
        public string Ip { get; set; }
        public string Port { get; set; } = "3000";

        private readonly IHost Host;

        public MainWindow()
        {

            ni.Icon = new Icon("trayicon.ico");
            ni.Visible = true;
            ni.DoubleClick += new EventHandler(ShowApp);
            ni.ContextMenuStrip = new ContextMenuStrip();
            ni.ContextMenuStrip.Items.Add("Show", null, ShowApp);
            ni.ContextMenuStrip.Items.Add("Close", null, CloseApp);

            try
            {
                Ip = Server.GetLocalIp();
                Host = Server.HostBuilder(Port);

                Host.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Localhost error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                Close();
            }

            InitializeComponent();

        }

        //private async void ChangePort(object sender, RoutedEventArgs e)
        //{
        //    await Host.StopAsync();
        //    Port = ((Button)sender).Tag as String;
        //    Host = Server.HostBuilder(Port);
        //    App.Current.Dispatcher.Invoke(() =>
        //    {
        //        label.Content = Port;
        //    });
        //    Host.Start();
        //}

        private void ClickTray(object Sender, EventArgs e)
        {
            ni.ContextMenuStrip = new ContextMenuStrip();
            ni.ContextMenuStrip.Items.Add("Show", null, ShowApp);
            ni.ContextMenuStrip.Items.Add("Close", null, CloseApp);
        }

        private void ShowApp(object Sender, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }

        void CloseApp(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
            base.OnStateChanged(e);
        }
    }
}