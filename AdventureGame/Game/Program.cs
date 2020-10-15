using System;

namespace Game
{
    class Program
    {
        static void Main()
        {
            ConsoleHelper.SetCurrentFont("Consolas", 32);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.White;
            Game.Start();
        }
    }
}
