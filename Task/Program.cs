using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskExplained
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // här användar jag inte await, då får vi tillbaka en Task<string>
            // "just nu är jag en Task, men i framtiden när anropet är klart blir jag en sträng"
            var iAmATask = client.GetStringAsync(@"https://coinlib.io/");

            // här användar jag await, då får vi tillbaka en string.
            // "jag väntar här tills vi har fått svar"
            var iAmAString = await client.GetStringAsync(@"https://coinlib.io/");

            // simulera ett tungt arbete i 1000 millisekunder
            await Task.Delay(1000);

            // kör metod i en ny tråd med Task.Run
            await Task.Run(() => HeavyWork());

            // Task.WhenAll används för att vänta tills flera tasks är klara
            var tasks = new List<Task>();
            tasks.Add(HeavyWorkAsync());
            tasks.Add(HeavyWorkAsync());
            tasks.Add(HeavyWorkAsync());
            Console.WriteLine("Waiting for tasks for complete");
            await Task.WhenAll(tasks);
            Console.WriteLine("Tasks completed");

        }

        private static void HeavyWork()
        {
            for (int i = 0; i < 2000000000; i++)
            {

            }
        }

        private static async Task HeavyWorkAsync()
        {
            await Task.Run(() => HeavyWork());
        }
    }
}
