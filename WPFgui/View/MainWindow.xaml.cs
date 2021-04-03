using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Specialized;


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
            this.DataContext = this;

            PomocnikEpuap.Core.ZipedEpuapPackage zip1 = new PomocnikEpuap.Core.ZipedEpuapPackage(@"C:\ePuap\21.zip");
            PomocnikEpuap.Core.EpuapDocument doc1 = zip1.UnZip();

            PomocnikEpuap.Core.ZipedEpuapPackage zip2 = new PomocnikEpuap.Core.ZipedEpuapPackage(@"C:\ePuap\2.zip");
            PomocnikEpuap.Core.EpuapDocument doc2 = zip2.UnZip();

            PomocnikEpuap.Core.ZipedEpuapPackage zip3 = new PomocnikEpuap.Core.ZipedEpuapPackage(@"C:\ePuap\3.zip");
            PomocnikEpuap.Core.EpuapDocument doc3 = zip3.UnZip();

            Documents.Add(new DocumentInfo(doc1.Title, doc1.SenderName, doc1.SendDate));
            Documents.Add(new DocumentInfo(doc2.Title, doc2.SenderName, doc2.SendDate));
            Documents.Add(new DocumentInfo(doc3.Title, doc3.SenderName, doc3.SendDate));

            Documents.ForEach(item => DocumentsList.Items.Add(item));
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

        public List<DocumentInfo> Documents = new List<DocumentInfo>();

        public class DocumentInfo
        {
            public DocumentInfo(string name, string senderName, DateTime sendDate) {
                Title = name;
                SenderName = senderName;
                SendDate = sendDate.ToShortDateString();
            }            
            public string Title { get; private set; }
            public string SenderName { get; private set; }
            public string SendDate { get; private set; }
        }
    }
}
