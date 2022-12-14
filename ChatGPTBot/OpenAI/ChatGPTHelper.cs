using ChatGPTBot.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTBot.OpenAI
{
    public class ChatGPTHelper
    {
        public static GPTResult CallChatGPT(string msg)
        {
            HttpClient client = new HttpClient();
            string uri = "https://api.openai.com/v1/completions";

            // Request headers.
            client.DefaultRequestHeaders.Add(
                "Authorization", "Bearer ___YOUR_TOKEN___");

            var JsonString = @"
            {
  ""model"": ""text-davinci-003"",
  ""prompt"": ""question"",
  ""max_tokens"": 4000,
  ""temperature"": 0
}
            ".Replace("question", msg);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            var response = client.PostAsync(uri, content).Result;
            var JSON = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<GPTResult>(JSON);
        }
    }
}
