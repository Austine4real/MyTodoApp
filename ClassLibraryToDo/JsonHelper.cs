using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibraryToDo
{
    internal class JsonHelper
    {
        public static string GetPath(string fileName)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + fileName)));
            return directory.FullName;
        }
    }
}
