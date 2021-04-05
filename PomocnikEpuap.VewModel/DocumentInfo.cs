using System;

namespace PomocnikEpuap.ViewModel
{
    public class PackageInfo
    {
        public PackageInfo(string name, string senderName, DateTime sendDate)
        {
            Title = "Tytuł: " + name;
            SenderName = "Nadawca: " + senderName;
            SendDate = "Data nadania: " + sendDate.ToShortDateString();
        }
        public string Title { get; private set; }
        public string SenderName { get; private set; }
        public string SendDate { get; private set; }
    }
}
