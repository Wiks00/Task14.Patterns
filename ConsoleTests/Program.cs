using System;
using System.Collections.Generic;
using System.Configuration;
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
            Configurator config;

            string enviroment = ConfigurationManager.AppSettings["Enviroment"];

            if (enviroment.Equals("Dev"))
            {
                config = new XmlConfig();
            }
            else if (enviroment.Equals("Prod"))
            {
         
                config = new DbConfig();
            }
            else
            {
                Console.WriteLine("No such value found in AppSettings");
                Console.ReadKey();

                return;
            }

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
