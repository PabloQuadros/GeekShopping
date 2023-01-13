using SankhyaAuthTester.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SankhyaAuthTester.Model
{
    public class CallID
    {
        [JsonPropertyName("$")]
        public string callId  { get; set; }
    }

    public class Idusu
    {
        [JsonPropertyName("$")]
        public string idusu  { get; set; }
        }

        public class Jsessionid
    {
            [JsonPropertyName("$")]
            public string jsessionid { get; set; }
        }

        public class KID
        {
            [JsonPropertyName("$")]
            public string kid { get; set; }
        }

        public class ResponseBody
    {
        public CallID callID { get; set; }
        public Jsessionid jsessionid { get; set; }
        public KID kID { get; set; }
        public Idusu idusu { get; set; }
    }

    public class SankhyaReturn
    {
        [JsonPropertyName("serviceName")]
        public string serviceName { get; set; }
        [JsonPropertyName("status")]
        public string status { get; set; }
        [JsonPropertyName("pendingPrinting")]
        public string pendingPrinting { get; set; }
        [JsonPropertyName("transactionId")]
        public string transactionId { get; set; }
        [JsonPropertyName("responseBody")]
        public ResponseBody responseBody { get; set; }
    }

}
