using Newtonsoft.Json;

namespace ConfigHandler
{
    public static class JSONSerializer
    {
        public static T Deserialize<T>(string fileLocation)
        {
            using (StreamReader r = new StreamReader(fileLocation))
            {
                string jsonData = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
        }
    }
}