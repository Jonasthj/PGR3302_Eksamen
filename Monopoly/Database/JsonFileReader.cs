using System.IO;
using Newtonsoft.Json.Linq;

namespace Monopoly.Database
{
    public static class JsonFileReader
    {
        public static JObject GetJsonData()
        {
            // SetJsonDirectory();
            
            // JSON Path.
            string jsonPath = "data.json";

            // Read JSON file.
            return JObject.Parse(File.ReadAllText(jsonPath));;
        }

        // private static void SetJsonDirectory()
        // {
        //     // TODO: Temp directory solution!!!
        //     Directory.SetCurrentDirectory("../../../Monopoly/Database/");
        // }
    }
}