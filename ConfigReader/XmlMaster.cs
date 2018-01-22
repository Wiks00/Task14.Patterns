using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigReader
{
    class XmlMaster : IConfigReader
    {
        private XmlDocument xmlConfig = new XmlDocument();
        string filePath = Path.Combine(Environment.CurrentDirectory, "config.xml");

        public XmlMaster()
        {
            xmlConfig.Load(filePath);
        }

        public string Read(string prop)
        {
            return xmlConfig.SelectSingleNode($"//{prop}")?.InnerText;
        }

        public void Write(string prop, string value)
        {
            var property = xmlConfig.SelectSingleNode($"//{prop}");

            if (property == null)
            {
                throw new XmlException($"{prop} do not exist");
            }

            property.InnerText = value;
        }

        public void Save()
        {
            xmlConfig.Save(filePath);
        }

        public void Dispose()
        {
            Save();
        }
    }
}
