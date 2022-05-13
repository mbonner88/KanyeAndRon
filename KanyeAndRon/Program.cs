using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeAndRon
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"");
                Console.WriteLine("Kanye West: " + "\"" + KanyeQuote() + "\"");
                Console.WriteLine("Ron Swanson: " + RonQuote());
            }
        }

        static string KanyeQuote()
        {
            var client = new HttpClient();
            var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
            return JObject.Parse(kanyeResponse).GetValue("quote").ToString();
        }

        static string RonQuote()
        {
            var client = new HttpClient();
            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            return JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
        }
    }
}
