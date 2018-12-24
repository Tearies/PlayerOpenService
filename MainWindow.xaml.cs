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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApiService.Factory.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ApiService.Factory.Stop();
        }
    }
}
