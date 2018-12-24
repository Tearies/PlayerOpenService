using System;
using System.Dynamic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Hosting.Engine;
using Owin;

namespace WebApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private IDisposable webservice { get; set; }
        private StartOptions options { get; set; }
     
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            options = new StartOptions();
            options.Urls.Add("http://+:9000");
            options.Urls.Add("http://+:9001");
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webservice = WebApp.Start(options, (p) =>
            {
                Console.WriteLine("Sample Middleware loaded...");
#if DEBUG
                p.UseErrorPage();
#endif
                p.UseWelcomePage();
                p.Use<SampleMiddleware>();
            
            });
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webservice?.Dispose();
        }
    }
}
