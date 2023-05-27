using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ClassLibraryToDo
{
    public class WriteToJson
    {
        public void WriteToJsons(List<User> user)
        {
            string GetFullPath = JsonHelper.GetPath("data.json");
            string jsonString = JsonSerializer.Serialize(user);
            using (StreamWriter writer = new StreamWriter(GetFullPath))
            {
                writer.Write(jsonString);
            }
            Console.WriteLine("Json is written");
        }
        //public void WriteToJsons(List<User> user)
        //{
        //    string fullPath = JsonHelper.GetPath("Augustine.json");

        //    string jsonString = JsonSerializer.Serialize(user);

        //    using (StreamWriter writer = new StreamWriter(fullPath))
        //    {
        //        writer.Write(jsonString);
        //    }

        //}
    }
}
