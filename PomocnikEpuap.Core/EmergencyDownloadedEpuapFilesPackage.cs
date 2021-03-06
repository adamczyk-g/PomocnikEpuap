using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Xml;



namespace PomocnikEpuap.Core
{
    public class EmergencyDownloadedEpuapFilesPackage
    {
        private readonly string packageFilePath;

        public EmergencyDownloadedEpuapFilesPackage(string packageFilePath)
        {
            this.packageFilePath = packageFilePath;
            XmlFileNames = new List<string>();
            //XmlFiles = new List<XmlDocument>();
        }
        public void Open() {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ZipArchive zipArchive = ZipFile.Open(packageFilePath, ZipArchiveMode.Read, System.Text.Encoding.GetEncoding(852));
                        
            foreach (ZipArchiveEntry z in zipArchive.Entries)
            {
                XmlFileNames.Add(z.Name);
                System.IO.Stream s = z.Open();
                XmlDocument xml = new XmlDocument();
                xml.Load(s);
                ////XmlFiles.Add(xml);
            }

            FilesCount = zipArchive.Entries.Count;
        }

        public int FilesCount { get; private set; }

        public List<string> XmlFileNames { get; private set; }

        //public List<XmlDocument> XmlFiles { get; private set; }

    }
}
