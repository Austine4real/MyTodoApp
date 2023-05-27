using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClassLibraryToDo
{
    internal class WriteToJson
    {
        public void WriteToJsons(List<User> users)
        {
            //string fileName = "data.json";
            //string currentDir = Environment.CurrentDirectory;
            //DirectoryInfo directory = new DirectoryInfo(
            //    Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\" + fileName)));
            string GetFullPath = JsonHelper.GetPath("data.json");
            string jsonString = JsonSerializer.Serialize(users);
            using (StreamWriter writer = new StreamWriter(GetFullPath))
            {
                writer.Write(jsonString);
            }
            Console.WriteLine("Json is written");
        }
    }
}
