using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReader
{
    public class DbConfig : Configurator
    {
        public DbConfig()
        {
            Console.WriteLine($"{typeof(DbConfig)} was born!");    
        }

        public override IConfigReader Create()
            => new DbMaster();
    }
}
