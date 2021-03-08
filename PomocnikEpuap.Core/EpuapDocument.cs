using System;
using System.Collections.Generic;

namespace PomocnikEpuap.Core
{
    public class EpuapDocument
    {
        //Adresaci (nazwa, adres)
        //DoWiadomosci (nazwa, adres) Carbon Copy

        public EpuapDocument(string identyfier, string title, DateTime sendDate, string senderName, string senderBox)
        {
            Identyfier = identyfier;
            Title = title;
            SendDate = sendDate;
            SenderName = senderName;
            SenderBox = senderBox;
        }

        public string Identyfier { get; private set; }
        public string Title { get; }
        public DateTime SendDate { get; }
        public string SenderName { get; }
        public string SenderBox { get; }
        public string RecipientName { get; }
        public string RecipientBox { get; }
        public string Content { get; }
        public List<Attachment> Attachements {get;}

    }
}
