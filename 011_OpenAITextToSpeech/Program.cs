

using System.Text;
using Newtonsoft.Json;

class Program
{
    private static readonly string apiKey = "api-key";

    static async Task Main(string[] args)
    {
        Console.Write("Metni Giriniz :");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Ses dosyası oluşturuluyor...");
            await GenerateSpeech(input);
            Console.WriteLine("Ses dosyası mp3 olarak kayıt edildi");

            System.Diagnostics.Process.Start("explorer.exe", "output.mp3");

        }

        static async Task GenerateSpeech(string text)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new
                {
                    model = "tts-1",
                    input = text,
                    voice = "alloy"
                    // echo,fable,onyx,nova,shimmer => farklı tonlamalar ve ses seçenekleri sunar.
                };

                string json = JsonConvert.SerializeObject(requestBody);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/audio/speech", content);

                if (response.IsSuccessStatusCode)
                {
                    byte[] audioBytes = await response.Content.ReadAsByteArrayAsync();
                    await File.WriteAllBytesAsync("output.mp3", audioBytes);
                }
                else
                {
                    Console.WriteLine("Bir hata oluştu");
                }
            }

        }
    }
}