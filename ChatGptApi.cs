using System.Text;

namespace SpecflowSeleniumMayBatchProject
{
    public class ChatGptApi
    {
        private static readonly string apiUrl = "https://api.openai.com/v1/chat/completions";
        public static string ApiKey()
        {
            return "sk-proj-yvl6do3PSQWoinlHePh0T3BlbkFJBguiQ0LAkBI1QiyAQYjQ";
        }


        [Test]
        public async Task ChatGptResponseMessage() 
        {
            var response = 
                await GetChatGPTResponse("Write code to open browser using selenium");
            Console.WriteLine(response);
        }

        public static async Task<string> GetChatGPTResponse(string prompt)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey()}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo", // Specify the model here
                    messages = new[]
                    {
                    new { role = "user", content = prompt }
                }
                };

                var jsonRequestBody = System.Text.Json.JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = System.Text.Json.JsonDocument.Parse(responseBody);

                return responseJson.RootElement
                                   .GetProperty("choices")[0]
                                   .GetProperty("message")
                                   .GetProperty("content")
                                   .ToString();
            }
        }
    }
}