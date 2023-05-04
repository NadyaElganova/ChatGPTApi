using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatGPTApi
{
    class ChatGptClient
    {
        private string openApiKey;
        private ChatGptRequest chatGptRequest;

        public ChatGptClient(string requestUser) 
        {
            openApiKey = "pk-XJqSMHHNtdbyFeQhIdaBIsTevFBCzDoBxFkSdZVkgzDRFHve";
            chatGptRequest = new ChatGptRequest();
            chatGptRequest.Model = "gpt-3.5-turbo";
            chatGptRequest.Messages = new MessageRequest[] { new MessageRequest (){ RoleRequest="user", ContentRequest = requestUser} };    
        }  

        public async Task<string> GetChatGptResponse()
        {
            using var httpClient = new HttpClient()
            {
                DefaultRequestHeaders =
                {
                    Authorization= AuthenticationHeaderValue.Parse($"Bearer {openApiKey}")
                }
            };
            var chatCompletionUri = "https://api.pawan.krd/v1/chat/completions";
            string json = JsonSerializer.Serialize<ChatGptRequest>(chatGptRequest);

            var content = new StringContent(json, MediaTypeHeaderValue.Parse("application/json"));
            HttpResponseMessage response = await httpClient.PostAsync(chatCompletionUri, content);
            ChatGptResponse? chatGptResponse = await response.Content.ReadFromJsonAsync<ChatGptResponse>();
            return chatGptResponse.Choices[0].Message.Content.ToString();
        }
    }
}
