using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClassLibraryToDo
{
    internal class ReadFromJSon
    {
        public List<User> ReadFromJsons(string fileName)
        {
            string jsonContent = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<User>>(jsonContent);
        }
    }
}
