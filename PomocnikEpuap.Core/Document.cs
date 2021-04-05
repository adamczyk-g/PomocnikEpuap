using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Linq;

namespace PomocnikEpuap.Core
{
    /// <summary>
    /// Does something.
    /// </summary>
    /// <param name="text">The text to process.</param>
    /// <returns>The result.</returns>
    /// <exception cref="XmlFileLoadingException"><paramref name="text"/> xml file load error</exception>

    public class Document: PackageContent
    {
        private  Document(string fileName, XmlDocument xmlDocument) 
        {
            FileName = fileName;
            content = xmlDocument;            
        }

        public static Document Create(string fileName, Stream fileContent)
        {
            return new Document(fileName, CreateXmlFromStream(fileName, fileContent));
        }

        public string FileName { get; private set; }
        public string Title => GetPropertyByName("Tytul");
        public string Identyfier => GetPropertyByName("CID");        
    }
}
