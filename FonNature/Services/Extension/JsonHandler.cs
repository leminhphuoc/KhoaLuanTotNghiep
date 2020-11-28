using Newtonsoft.Json;

namespace FonNature.Services.Extension
{
    public static class JsonHandler
    {
        public static T ParseToObject<T>(this string json)
        {
            if(string.IsNullOrWhiteSpace(json))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ParseToJson(this object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            return JsonConvert.SerializeObject(data);
        }
    }
}