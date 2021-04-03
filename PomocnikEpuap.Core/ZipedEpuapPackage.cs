using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Xml;

namespace PomocnikEpuap.Core
{
    public class ZipedEpuapPackage
    {
        private readonly string packageFilePath;

        public ZipedEpuapPackage(string packageFilePath)
        {
            this.packageFilePath = packageFilePath;
            XmlFileNames = new List<string>();
        }
        public EpuapDocument UnZip() {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ZipArchive zipArchive = ZipFile.Open(packageFilePath, ZipArchiveMode.Read, System.Text.Encoding.GetEncoding(852));

            EpuapXmlFile descriptor = null, document = null;

            List<EpuapXmlFile> plikiXml = new List<EpuapXmlFile>();

            foreach (ZipArchiveEntry zipEntry in zipArchive.Entries)
            {
                XmlFileNames.Add(zipEntry.Name);             

                EpuapXmlFile epuapXmlFile = EpuapXmlFile.Create(zipEntry.Name, zipEntry.Open());

                if (zipEntry.Name == "Deskryptor.xml")
                    descriptor = epuapXmlFile;
                else 
                    document = epuapXmlFile;
            }

            FilesCount = zipArchive.Entries.Count;

            return new EpuapDocument(descriptor, document);
        }

        public int FilesCount { get; private set; }

        public List<string> XmlFileNames { get; private set; }
    }
}
