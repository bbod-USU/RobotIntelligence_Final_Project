using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp
{
    public class JsonDeserializor : IJsonDeserializor
    {
        public T DeserializeObject<T>(string filePath)
        {
            var jString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jString);
        }
    }
}