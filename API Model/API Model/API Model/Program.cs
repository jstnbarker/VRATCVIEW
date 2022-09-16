using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Newtonsoft.Json; // Project -> Manage NuGet Packages -> Search for Newtonsoft
using Newtonsoft.Json.Linq;

namespace Program
{
    internal class airplane
    {
        public double z = 0;
        public double x = 0;
        public double y = 0;
        public double heading = 0;

        public airplane(double z, double y, double x, double heading)
        {
            this.z = z;
            this.y = y;
            this.heading = heading;
            this.x = x;
        }
    }
    class Program
    {
        static double latn = 34;
        static double lonn = -84.61907;
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
            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            Console.WriteLine(result.Keys.ElementAt(0));
            var value = new object();
            object ac = new object();

            if (result.TryGetValue("ac", out value))
            {
                ac = result["ac"];
            }

            ArrayList aircraft = new ArrayList();
            foreach (var i in (JArray)ac)
            {
                double lattemp = (double)i["lat"] - latn;
                double lontemp = (double)i["lon"] - lonn;
                double alttemp = 0;
                try
                {
                    alttemp = (double)i["alt_baro"];
                }
                catch (Exception e) { };

                double headtemp = 0;
                try
                {
                    headtemp = (double)i["track"];
                }
                catch(Exception e){};
                

                Console.WriteLine(lattemp + "  " + lontemp + "  " + alttemp + " " + headtemp);

                aircraft.Add(new airplane(alttemp, lattemp, lontemp, headtemp));
            }
        }
    }
}
