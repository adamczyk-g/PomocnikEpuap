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
                throw new XmlFileLoadingException("Nie udało się wczytać pliku xml " + fileName + "z archiwum!", xmlException);
            }

            return new EpuapXmlFile(fileName, xmlDocument);
        }
        public string FileName { get; private set; }
        public string GetFirstField (string data){

            //XmlNameTable table = xmlDocument.names;

            XmlNodeList elemList = xmlDocument.GetElementsByTagName(data);
            return elemList[0].InnerXml;
        }
        public IEnumerable<string> GetAllFields(string data)
        {
            ReadNamespaces();
            XmlElement xmlElem = xmlDocument.DocumentElement;
            //var node = xmlElem.SelectSingleNode(data, ReadNamespaces());
            XmlNodeList list = xmlElem.SelectNodes(data, ReadNamespaces());
            IEnumerable<string> query =  list.Cast<XmlNode>().Select(x=>x.InnerText);

            //return node.InnerText;
            return query;
        }
        public XmlNamespaceManager ReadNamespaces() {

            XmlNodeList _xmlNameSpaceList = xmlDocument.SelectNodes(@"//namespace::*[not(. = ../../namespace::*)]");
            XmlNamespaceManager _xmlNSmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            foreach (XmlNode nsNode in _xmlNameSpaceList)
            {
                _xmlNSmgr.AddNamespace(nsNode.LocalName, nsNode.Value);
            }

            return _xmlNSmgr;
        }

    }
}
