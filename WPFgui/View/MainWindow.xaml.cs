using PomocnikEpuap.ViewModel;
using System.Windows;

namespace WPFgui.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open button is clicked.");
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Help button is clicked.");
        }
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("About button is clicked.");
        }        
    }
}
