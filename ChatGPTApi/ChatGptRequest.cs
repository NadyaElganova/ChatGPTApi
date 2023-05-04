using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatGPTApi
{
    public partial class ChatGptRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("messages")]
        public MessageRequest[] Messages { get; set; }
    }

    public partial class MessageRequest
    {
        [JsonPropertyName("role")]
        public string RoleRequest { get; set; }

        [JsonPropertyName("content")]
        public string ContentRequest { get; set; }
    }
}
