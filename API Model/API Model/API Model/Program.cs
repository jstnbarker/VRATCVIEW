using System.Collections;
using System.Text.Json;
using System.Threading;



namespace Program
{
    class Program
    {
        static async Task<string> apireq()
        {
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://adsbexchange-com1.p.rapidapi.com/v2/lat/34/lon/-84.61907/dist/25/"),
                    Headers =
                {
                    { "X-RapidAPI-Key", "eb8d552955msh489af4a2a68aaa6p163cefjsne986c91a31f7" },
                    { "X-RapidAPI-Host", "adsbexchange-com1.p.rapidapi.com" },
                },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
            }
        }
        public static void Main(string[] args)
        {
            Task<string> apitask = apireq();
            string jsonString = apitask.Result;

            Thread.Sleep(10000);
        }
    }
}
