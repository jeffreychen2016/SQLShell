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

            Console.WriteLine("Press any key to run your query.");
            Console.ReadLine();

            var DbCommand = DbConnection.CreateCommand();
            DbCommand.CommandText = new ReadFromFile().ReadFileThenReturnQueryString();

            var DbReader = DbCommand.ExecuteReader();
            new WriteToFile().WriteQueryResultToFile(DbReader);

            DbReader.Close();
            DbCommand.Dispose();
            DbConnection.Close();
        }
    }
}
