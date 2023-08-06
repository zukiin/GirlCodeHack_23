using System;
using RestSharp;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace she_innovates.Models
{
	public class ChatGPTClient
	{
        private readonly HttpClient httpClient;
        private readonly string apiKey;

        public ChatGPTClient(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient = new HttpClient();
        }

        public async Task<string> GetChatResponse(string message)
        {
            string apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";
            string prompt = "You are a helpful assistant.\nUser: " + message + "\nAssistant:";

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);
            var requestData = new { prompt = prompt, max_tokens = 150 };

            var requestContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiUrl, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                // Extract the model's generated text from the response and return it.
                return ExtractGeneratedText(responseContent);
            }
            else
            {
                // Handle API error responses.
                return "Error: " + response.StatusCode.ToString();
            }
        }

        private string ExtractGeneratedText(string jsonResponse)
        {
            return "";
            //try
            //{
            //    // Parse the JSON response to a JObject
            //    JObject responseObject = JObject.Parse(jsonResponse);

            //    // Get the 'choices' array from the response
            //    JArray choices = (JArray)responseObject["choices"];

            //    if (choices != null && choices.Count > 0)
            //    {
            //        // Get the first choice (assumes only one choice)
            //        JObject firstChoice = (JObject)choices[0];

            //        // Extract and return the generated text (the 'text' property)
            //        string generatedText = firstChoice["text"].ToString();
            //        return generatedText;
            //    }
            //    else
            //    {
            //        // Handle case when 'choices' array is empty or not present in the response
            //        return "Error: No generated text found in the response.";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle JSON parsing or other exceptions that might occur
            //    return "Error: " + ex.Message;
            //}
        }
    }
}

