using System.Windows;

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
