using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Bank
{
    public sealed class JsonSerializator
    {
        public static void ToJson(List<Owner> owner, string path)
        {
            //TODO: check if file by path exist
            
            var existsData = FromJson(path);

            if (existsData != null)
            {
                owner = owner.Concat(existsData).ToList();
            }

            var jsonData = JsonConvert.SerializeObject(owner);
            
            using (var streamWriter = new StreamWriter(path))
            {
                //TODO: better in async way
                streamWriter.Write(jsonData);
            }
        }

        public static List<Owner> FromJson(string path)
        {
            //TODO: check if file by path exist
            
            string owner;
            using (var streamReader = new StreamReader(path) )
            {
                //TODO: better in async way
                owner = streamReader.ReadToEnd();
            }
            
            return JsonConvert.DeserializeObject<List<Owner>>(owner);
        }
    }
}
