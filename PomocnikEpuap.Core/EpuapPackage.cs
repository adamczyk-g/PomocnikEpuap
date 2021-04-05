using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

namespace PomocnikEpuap.Core
{
    public class EpuapPackage
    {
        private readonly Descriptor descriptor;
        private readonly Document document;

        public EpuapPackage(Descriptor descriptor, Document document)
        {
            this.descriptor = descriptor;
            this.document = document;            
        }
        public string Title => document.Title;
        public string SenderName => descriptor.SenderName;
        public string SenderBox => descriptor.SenderBox;
        public string Content => descriptor.Content;
        /*public EpuapDocument Document
        {/*
                string id = document.GetFirstField("str:CID");
                DateTime date = DateTime.ParseExact(descriptor.GetFirstField("DataNadania"), "dd.MM.yyyyTHH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture);
                string senderBox = descriptor.GetFirstField("AdresOdpowiedzi");
                //string content = descriptor.GetFirstField("wnio:Informacja");
                IEnumerable<string> adresaci = document.GetAllFields("//wnio:Dokument//wnio:DaneDokumentu//str:Adresaci//meta:Podmiot//inst:Instytucja");
        }*/

        public string Identyfier => document.Identyfier;
        public DateTime SendDate
        {
            get {          
                return DateTime.ParseExact(RemoveMilisecondsFromDate(descriptor.SendDate), "dd.MM.yyyyTHH:mm:ss", CultureInfo.InvariantCulture); }
        }
        private string RemoveMilisecondsFromDate(string date) =>  date.Substring(0, date.LastIndexOf('.'));        
        public string RecipientName { get; }
        public string RecipientBox { get; }        
        public List<Attachment> Attachements { get; }
    }
}
