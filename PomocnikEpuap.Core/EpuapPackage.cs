using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PomocnikEpuap.Core
{
    public class EpuapPackage
    {
        private readonly EpuapXmlFile descriptor;
        private readonly EpuapXmlFile document;

        public EpuapPackage(EpuapXmlFile descriptor, EpuapXmlFile document)
        {
            if (descriptor != null) FileCount = 1;
            if (document != null) FileCount = 2;
            this.descriptor = descriptor;
            this.document = document;

        }

        public int FileCount { get; private set; }

        public EpuapDocument CreateDocument()
        {

            string id = document.GetField("str:CID"); 
            string tytul = document.GetField("wnio:Tytul");
            DateTime date = DateTime.ParseExact(descriptor.GetField("DataNadania"), "dd.MM.yyyyTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            string senderName = descriptor.GetField("NazwiskoNazwa");
            string senderBox = descriptor.GetField("AdresOdpowiedzi");
            return new EpuapDocument(id,tytul,date, senderName, senderBox);
        }
    }
}
