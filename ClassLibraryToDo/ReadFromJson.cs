using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClassLibraryToDo
{
    public class ReadFromJson
    {
        public List<User> ReadFromJsons(string fileName)
        {
            string jsonContent = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<User>>(jsonContent);
        }
        //public List<User> ReadFromJsons(string fileName)
        //{
        //    string path = JsonHelper.GetPath(fileName);

        //    string jsonContent = File.ReadAllText(path);

        //    return JsonSerializer.Deserialize<List<User>>(jsonContent);

        //}
    }
}
