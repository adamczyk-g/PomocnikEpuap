using System.Collections.ObjectModel;
using PomocnikEpuap.Core;

namespace PomocnikEpuap.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<PackageInfo> Packages { get; private set; }
        public MainViewModel()
        {
            Packages = new ObservableCollection<PackageInfo>();
            Initialize();
        }
        private void Initialize()
        {
            EpuapPackage doc1 = new ZippedEpuapPackage(@"..\..\..\..\SampleEpuapPackages\sample_package_1.zip").UnZip();
            EpuapPackage doc2 = new ZippedEpuapPackage(@"..\..\..\..\SampleEpuapPackages\sample_package_2.zip").UnZip();

            Packages.Add(new PackageInfo(doc1.Title, doc1.SenderName, doc1.SendDate));
            Packages.Add(new PackageInfo(doc2.Title, doc2.SenderName, doc2.SendDate));
            /*
            EpuapPackage doc3 = new ZippedEpuapPackage(@"C:\ePuap\21.zip").UnZip();
            EpuapPackage doc4 = new ZippedEpuapPackage(@"C:\ePuap\2.zip").UnZip();
            EpuapPackage doc5 = new ZippedEpuapPackage(@"C:\ePuap\3.zip").UnZip();

            Packages.Add(new PackageInfo(doc3.Title, doc3.SenderName, doc3.SendDate));
            Packages.Add(new PackageInfo(doc4.Title, doc4.SenderName, doc4.SendDate));
            Packages.Add(new PackageInfo(doc5.Title, doc5.SenderName, doc5.SendDate));*/
        }
    }
}
