using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigReader;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Configurator config = new XmlConfig();

            using (IConfigReader reader = config.Create())
            {
                Console.WriteLine(reader.Read("second"));

                reader.Write("second", "second");

                Console.WriteLine(reader.Read("second"));
            }

            config = new DbConfig();

            using (IConfigReader reader = config.Create())
            {
                Console.WriteLine(reader.Read("first"));

                reader.Write("first", "first");

                Console.WriteLine(reader.Read("first"));
            }

            Console.ReadKey();
        }
    }
}
