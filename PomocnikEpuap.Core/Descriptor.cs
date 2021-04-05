using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace PomocnikEpuap.Core
{
    public class Descriptor: PackageContent
    {
        private readonly XmlDocument descriptorXmlFile;
        private  Descriptor(string fileName, XmlDocument descriptorXmlFile)
        {
            this.content = descriptorXmlFile;
        }
        public static Descriptor Create(string fileName, Stream fileContent)
        {
            return new Descriptor(fileName, CreateXmlFromStream(fileName, fileContent));
        }

        public string SenderName => GetPropertyByName( "NazwiskoNazwa");
        public string SenderBox => GetPropertyByName( "AdresOdpowiedzi");
        public string Content => GetPropertyByName( "Informacja");
        public string SendDate => GetPropertyByName("DataNadania");
    }
}
