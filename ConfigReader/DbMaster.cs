using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReader
{
    public class DbMaster : IConfigReader
    {
        private SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDb;initial catalog=Northwind;integrated security=True");
        private SqlCommand command ;

        public DbMaster()
        {
            connection.Open();
            command = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ConfigTable'", connection);

            if ((int)command.ExecuteScalar() == 0)
            {
                command.CommandText = @"CREATE TABLE [dbo].[ConfigTable](
                    [first][varchar](100) NULL,
                    [second] [varchar] (100) NULL,
                    [third] [varchar] (100) NULL
                    ) ON[PRIMARY]";

                command.ExecuteNonQuery();
            }    
        }

        public string Read(string prop)
        {
            command.CommandText = $"SELECT TOP 1 [{prop}] FROM [dbo].[ConfigTable]";

            return command.ExecuteScalar() as string;
        }

        public void Write(string prop, string value)
        {
            command.CommandText = $"UPDATE [dbo].[ConfigTable] SET [{prop}] = '{value}'";

            if (command.ExecuteNonQuery() == 0)
            {
                command.CommandText = $"INSERT INTO [dbo].[ConfigTable] ({prop}) VALUES ('{value}')";
                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
