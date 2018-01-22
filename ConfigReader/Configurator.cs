using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReader
{
    public abstract class Configurator
    {
        public abstract IConfigReader Create();
    }
}
