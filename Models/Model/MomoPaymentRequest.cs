using Newtonsoft.Json;

namespace Models.Model
{
    public class MomoPaymentRequest
    {
        [JsonProperty("accessKey")]
        public string AccessKey { get; set; }

        [JsonProperty("partnerCode")]
        public string PartnerCode { get; set; }

        [JsonProperty("requestType")]
        public string RequestType { get; set; }

        [JsonProperty("ipnUrl")]
        public string IpnUrl { get; set; }

        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("orderInfo")]
        public string OrderInfo { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("extraData")]
        public string ExtraData { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
