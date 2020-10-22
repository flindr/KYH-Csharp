using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace DownloadWebsites
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var coinlib = client.GetStringAsync(@"https://coinlib.io/");
            var google = client.GetStringAsync(@"https://www.google.com/");
            var github = client.GetStringAsync(@"https://www.github.com/");

            var allSites = await Task.WhenAll(coinlib, google, github);

            stopWatch.Stop();

            Console.WriteLine($"Downloading all sites took {stopWatch.ElapsedMilliseconds} ms.");

        }
    }
}
