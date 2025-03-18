using System.Text;
using System.Text.Json;

namespace _020_RecipeSuggestion.Models
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private const string OpenAiUrl = "https://api.openai.com/v1/chat/completions";
        private const string apiKey = "";


        public OpenAIService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }


        public async Task<string> GetRecipeAsync(string ingredients)
        {
            var requestBody = new
            {
                model = "gpt-4",
                messages = new[]
                {
                    new {role="system",content="sen profesyonel bir aşçısın. kullanıcının elindeki malzemelere göre yemek öner"},
                    new {role="user",content=$"elimde şu malzemeler var bu malzemeler ile hangi yemeği yapabilirim"}
                },
                temperature = 0.7
            };
            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var response =await _httpClient.PostAsync(OpenAiUrl, new StringContent(jsonRequest, Encoding.UTF8, "application/json"));
            var responseBody = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(responseBody);
            return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
    }
}
