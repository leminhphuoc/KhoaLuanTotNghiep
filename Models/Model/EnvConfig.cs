using Newtonsoft.Json;

namespace Models.Model
{
    public class EnvConfig
    {
        [JsonProperty("env")]
        public string Enviroment { get; set; }

        [JsonProperty("partnerCode")]
        public string PartnerCode { get; set; }

        [JsonProperty("accessCode")]
        public string AccessCode { get; set; }

        [JsonProperty("requestType")]
        public string RequestType { get; set; }

        [JsonProperty("secrectKey")]
        public string SecrectKey { get; set; }

        [JsonProperty("requestUrl")]
        public string RequestUrl { get; set; }
    }
}
