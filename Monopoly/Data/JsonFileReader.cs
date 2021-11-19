using System.IO;
using Newtonsoft.Json.Linq;

namespace Monopoly.Data
{
    public static class JsonFileReader
    {
        public static JObject GetJsonData()
        {
            SetJsonDirectory(@"../../../../Monopoly/Database/");
            
            // JSON Path.
            const string jsonPath = "data.json";

            // Read JSON file.
            return JObject.Parse(File.ReadAllText(jsonPath));
        }

        private static void SetJsonDirectory(string path)
        {
            if (Directory.Exists(path))
                Directory.SetCurrentDirectory(path);
        }
    }
}