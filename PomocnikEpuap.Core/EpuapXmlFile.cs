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

    public class EpuapXmlFile
    {
        private readonly XmlDocument xmlDocument;

        private  EpuapXmlFile(string fileName, XmlDocument xmlDocument) 
        {
            FileName = fileName;
            this.xmlDocument = xmlDocument;
        }
        public static EpuapXmlFile Create(string fileName, Stream fileContent)
        {
            XmlDocument xmlDocument = new XmlDocument();

            try
            {                
                xmlDocument.Load(fileContent);
            }
            catch (XmlException xmlException)
            {
                throw new XmlFileLoadingException("Nie udało się wyodrębnić pliku xml " + fileName + "z archiwum!", xmlException);
            }

            return new EpuapXmlFile(fileName, xmlDocument);
        }
        public string FileName { get; private set; }
        public string GetFirstField (string data){
            XmlNode singleNode = xmlDocument.SelectSingleNode("//*[contains(name(),'" + data + "')]");
            return singleNode.InnerXml;
        }
    }
}
