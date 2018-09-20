using System;
using System.Data.Odbc;
using System.IO;

namespace SQLShell
{
    public class WriteToFile
    {
        public void WriteQueryResultToFile(OdbcDataReader DbReader)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fullName = Path.Combine(desktopPath, "result.txt");

            var ColumnCount = DbReader.FieldCount;
            var ListOfColumns = string.Empty;

            while (DbReader.Read())
            {
                for (int i = 0; i <= ColumnCount - 1; i++)
                {
                    ListOfColumns += DbReader[i].ToString() + "|";
                }

                ListOfColumns += Environment.NewLine;
            }

            var tw = new StreamWriter(fullName);
            tw.WriteLine(ListOfColumns);
            tw.Close();
        }
    }
}
