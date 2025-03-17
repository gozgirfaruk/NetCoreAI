
using System.Text;
using System.Text.Json;

class Porgram
{
    private static readonly string apiKey = "";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Hikaye Türünü Seçiniz ( Macera,Korku,Bilim Kurgu,Fantastik,Komedi) :");
        string genre = Console.ReadLine();

        Console.WriteLine("Ana karakteriniz kim?");
        string character = Console.ReadLine();

        Console.WriteLine("Mekan Yazınız");
        string setting = Console.ReadLine();

        Console.WriteLine("Hika Uzunluğu (kısa-orta-uzun)");
        string length = Console.ReadLine();


        string prompt = $"{genre} türünde bir hikaye yaz. Baş karakter {character}. Hikaye {setting} bölgesinde geçiyor. {length} uzunlukta bir hikaye olsun ve hikayenin bir giriş gelişme sonuç olay örgüsü olsun.";

        string story = await GenerateStory(prompt);
        Console.WriteLine("-- AI tarafından yazılan hikaye --");
        Console.WriteLine(story);

    }

    static async Task<string> GenerateStory(string prompt)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var requestBody = new
        {
            model = "gpt-4-turbo",
            messages = new[]
            {
                new {role="system", content="You are a creative story writer."},
                new {role="user",content=prompt}
            },
            max_tokens = 1000
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);


        string responseContent = await response.Content.ReadAsStringAsync();
        JsonDocument doc = JsonDocument.Parse(responseContent);
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}