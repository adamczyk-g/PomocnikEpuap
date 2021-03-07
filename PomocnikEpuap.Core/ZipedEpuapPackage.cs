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

        public ZipedEpuapPackage(string packageFilePath)//unzpip provider
        {
            this.packageFilePath = packageFilePath;
            XmlFileNames = new List<string>();
            //XmlFiles = new List<XmlDocument>();
        }
        public EpuapPackage UnZip() {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ZipArchive zipArchive = ZipFile.Open(packageFilePath, ZipArchiveMode.Read, System.Text.Encoding.GetEncoding(852));

            XmlDocument descriptor, document;

            if (zipArchive.Entries.Count != 2) { /*nie obsługiwana ilość plików w paczce*/}

            List<XmlDocument> plikiXml = new List<XmlDocument>();

            foreach (ZipArchiveEntry zipEntry in zipArchive.Entries)
            {
                XmlFileNames.Add(zipEntry.Name);

                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(zipEntry.Open());

                plikiXml.Add(xmlFile);
            }

            FilesCount = zipArchive.Entries.Count;
            //EpuapXmlFile with name
            //jeśli nie ma pliku deskryptor ....paczka uszkodzona
            //

            return new EpuapPackage(descriptor, document);
        }

        public int FilesCount { get; private set; }

        public List<string> XmlFileNames { get; private set; }

        //public List<XmlDocument> XmlFiles { get; private set; }

    }
}
