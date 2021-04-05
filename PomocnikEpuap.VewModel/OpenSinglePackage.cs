namespace PomocnikEpuap.ViewModel
{
    public class OpenSinglePackage
    {
        public PackageInfo FromPath(string path)
        {
            PomocnikEpuap.Core.EpuapPackage doc = new PomocnikEpuap.Core.ZippedEpuapPackage(path).UnZip();

            return new PackageInfo(doc.Title, doc.SenderName, doc.SendDate);
        }

        public PackageInfo FromFixedPath()
        {
            string path = string.Empty;
            return FromPath(path);
        }
    }
}
