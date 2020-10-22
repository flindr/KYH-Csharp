using System;
using System.Threading.Tasks;

namespace MakingTea
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MakeTeaAsync();
        }

        private async static Task MakeTeaAsync()
        {
            var boilingWater = BoilWaterAsync();

            Console.WriteLine("3. Ta ut koppar");

            Console.WriteLine("4. Lägga tepåsar i kopparna");

            await boilingWater;

            Console.WriteLine($"6. Fylla kopparna med kokande vatten");
        }

        private async static Task BoilWaterAsync()
        {
            Console.WriteLine("1. Starta vattenkokaren");

            Console.WriteLine("2. Vänta på att vattnet kokar");

            await Task.Delay(2000);

            Console.WriteLine("5. Vattnet kokar!");
        }
    }
}
