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
            string id = document.GetFirstField("str:CID"); 
            string tytul = document.GetFirstField("wnio:Tytul");
            DateTime date = DateTime.ParseExact(descriptor.GetFirstField("DataNadania"), "dd.MM.yyyyTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
            string senderName = descriptor.GetFirstField("NazwiskoNazwa");
            string senderBox = descriptor.GetFirstField("AdresOdpowiedzi");
            //string content = descriptor.GetFirstField("wnio:Informacja");

            IEnumerable<string> adresaci = document.GetAllFields("//wnio:Dokument//wnio:DaneDokumentu//str:Adresaci//meta:Podmiot//inst:Instytucja");

            return new EpuapDocument(id,tytul,date, senderName, senderBox);
        }
    }
}
