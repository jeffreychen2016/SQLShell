using System;
using System.IO;

namespace SQLShell
{
    public class ReadFromFile
    {
        // always read from test.txt on desktop
        public string ReadFileThenReturnQueryString()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fullName = Path.Combine(desktopPath, "test.txt");
            var query = "";

            using (StreamReader sr = new StreamReader(fullName))
            {
                query = sr.ReadToEnd();
            }

            return query;
        }
    }
}
