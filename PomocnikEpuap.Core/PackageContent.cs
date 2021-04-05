using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace PomocnikEpuap.Core
{
    public abstract class PackageContent
    {
        protected XmlDocument content;

        protected string GetPropertyByName(string propertyName)
        {
            XmlNode singleNode = content.SelectSingleNode("//*[contains(name(),'" + propertyName + "')]");
            return singleNode.InnerXml;
        }
        protected static XmlDocument CreateXmlFromStream(string fileName, Stream fileContent)
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

            return xmlDocument;
        }
    }
}
