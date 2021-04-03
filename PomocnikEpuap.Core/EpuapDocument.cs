using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PomocnikEpuap.Core
{
    public class EpuapDocument
    {
        private readonly EpuapXmlFile descriptor;
        private readonly EpuapXmlFile document;

        public EpuapDocument(EpuapXmlFile descriptor, EpuapXmlFile document)
        {
            if (descriptor != null) FileCount = 1;
            if (document != null) FileCount = 2;
            this.descriptor = descriptor;
            this.document = document;
        }
        public int FileCount { get; private set; }
        public string Title => document.GetFirstField("Tytul");
        public string SenderName => descriptor.GetFirstField("NazwiskoNazwa");
        public string SenderBox => descriptor.GetFirstField("AdresOdpowiedzi");
        public string Content => descriptor.GetFirstField("Informacja");
        /*public EpuapDocument Document
        {/*
                string id = document.GetFirstField("str:CID");
                DateTime date = DateTime.ParseExact(descriptor.GetFirstField("DataNadania"), "dd.MM.yyyyTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                string senderBox = descriptor.GetFirstField("AdresOdpowiedzi");
                //string content = descriptor.GetFirstField("wnio:Informacja");
                IEnumerable<string> adresaci = document.GetAllFields("//wnio:Dokument//wnio:DaneDokumentu//str:Adresaci//meta:Podmiot//inst:Instytucja");
        }*/

        public string Identyfier => document.GetFirstField("CID");
        public DateTime SendDate
        {
            get {
                string date = descriptor.GetFirstField("DataNadania");                
                return DateTime.ParseExact(RemoveMilisecondFromDate(date), "dd.MM.yyyyTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); }
        }
        private string RemoveMilisecondFromDate(string date)
        { 
            return date.Substring(0, date.LastIndexOf('.'));
        }
        public string RecipientName { get; }
        public string RecipientBox { get; }        
        public List<Attachment> Attachements { get; }
    }
}
