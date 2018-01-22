using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReader
{
    public class XmlConfig : Configurator
    {
        public XmlConfig()
        {
            Console.WriteLine($"{typeof(XmlConfig)} was born!");
        }

        public override IConfigReader Create()
            => new XmlMaster();
    }
}
