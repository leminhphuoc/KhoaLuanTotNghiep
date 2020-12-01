using Newtonsoft.Json;

namespace Models.Model
{
    public class MomoPaymentResponse
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("localMessage")]
        public string LocalMessage { get; set; }

        [JsonProperty("requestType")]
        public string RequestType { get; set; }

        [JsonProperty("payUrl")]
        public string PayUrl { get; set; }

        [JsonProperty("qrCodeUrl")]
        public string QrCodeUrl { get; set; }

        [JsonProperty("deeplinkWebInApp")]
        public string DeeplinkWebInApp { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
