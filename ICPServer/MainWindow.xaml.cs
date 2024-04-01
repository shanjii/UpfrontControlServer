using System.Net.Sockets;
using System.Net;
using System.Windows;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;


namespace ICPServer
{

    public partial class MainWindow : Window
    {

        private readonly NotifyIcon ni = new()
        {
            Icon = new Icon("assets/appIcon.ico"),
            Visible = true
        };

        public string Ip { get; } = "";
        public string Port { get; } = "3000";


        public MainWindow()
        {
            var hosts = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in hosts.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (ip.ToString().Contains("192."))
                    {
                        Ip = ip.ToString();
                    };
                }
            }

            ni.DoubleClick += new EventHandler(ShowApp!);
            ni.Click += new EventHandler(ClickTray!);

            IHost server = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseUrls($"http://*:{Port}");
                webHostBuilder.UseStartup<Startup>();
            }).Build();

            server.Start();

            //RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)!;
            //key.SetValue("ICPServer", Environment.ProcessPath!);
            //key.DeleteValue("ICPServer");

            InitializeComponent();
        }

        private void ClickTray(object Sender, EventArgs e)
        {
            ni.ContextMenuStrip = new ContextMenuStrip();
            ni.ContextMenuStrip.Items.Add("Show", null, ShowApp!);
            ni.ContextMenuStrip.Items.Add("Close", null, CloseApp!);
        }

        void MenuTest2_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
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