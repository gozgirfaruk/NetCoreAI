using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using _003_RapidApi.ViewModels;
using Newtonsoft.Json;

var client = new HttpClient();

List<ApiSeeries> seeriesList = new List<ApiSeeries>();


var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
    Headers =
    {
        { "x-rapidapi-key", "40a677b018msh0b31180528e9fa5p1d8a4djsn1287d501ddd8" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    seeriesList = JsonConvert.DeserializeObject<List<ApiSeeries>>(body);
  foreach(var item in seeriesList)
    {
        Console.WriteLine(item.title + " " + item.rating);
    }
}
