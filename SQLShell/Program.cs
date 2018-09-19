using System;
using System.Data.Odbc;

namespace SQLShell
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter DSN that you want to connect to: ");

            var DSN = Console.ReadLine();
            var DbConnection = new OdbcConnection("DSN=" + DSN);

            DbConnection.Open();

            Console.Write("SQL-> ");

            var query = Console.ReadLine();
 

            var DbCommand = DbConnection.CreateCommand();
            DbCommand.CommandText = query;
            var DbReader = DbCommand.ExecuteReader();

            int fCount = DbReader.FieldCount;
            for (int i = 0; i < fCount; i++)
            {
                var fName = DbReader.GetName(i);
                Console.Write(fName + ":");
            }
            Console.WriteLine();

            while (DbReader.Read())
            {
                Console.Write(":");
                for (int i = 0; i < fCount; i++)
                {
                    String col = DbReader.GetString(i);

                    Console.Write(col + ":");
                }
                Console.WriteLine();
            }

            DbReader.Close();
            DbCommand.Dispose();
            DbConnection.Close();
        }
    }
}
