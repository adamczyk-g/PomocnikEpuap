using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Xml;

namespace PomocnikEpuap.Core
{
    public class ZippedEpuapPackage
    {
        private readonly string packageFilePath;

        public ZippedEpuapPackage(string packageFilePath)//unzpip provider
        {
            this.packageFilePath = packageFilePath;
            XmlFileNames = new List<string>();
        }
        public EpuapPackage UnZip() {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ZipArchive zipArchive = ZipFile.Open(packageFilePath, ZipArchiveMode.Read, System.Text.Encoding.GetEncoding(852));

            Descriptor descriptor = null;
            Document document = null;

            List<Document> plikiXml = new List<Document>();

            foreach (ZipArchiveEntry zipEntry in zipArchive.Entries)
            {
                XmlFileNames.Add(zipEntry.Name);


                if (zipEntry.Name == "Deskryptor.xml")
                    descriptor = Descriptor.Create(zipEntry.Name, zipEntry.Open());
                else 
                    document = Document.Create(zipEntry.Name, zipEntry.Open());
            }

            FilesCount = zipArchive.Entries.Count;

            return new EpuapPackage(descriptor, document);
        }

        public int FilesCount { get; private set; }

        public List<string> XmlFileNames { get; private set; }

    }
}
