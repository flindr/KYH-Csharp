using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public static class UI
    {
        public const int WorldWidth = 60, WorldHeight = 20;
        public const int LogWidth = Game.WindowWidth, LogHeight = 10;
        private const int InventoryWidth = 20, InventoryHeight = 10;
        private const int StatsWidth = 20, StatsHeight = 10;
        private const char EmptySymbol = '\0';
        private static Coordinate WorldStartPosition = new Coordinate(0, 0);
        private static Coordinate StatsStartPosition = new Coordinate(WorldWidth, 0);
        private static Coordinate InventoryStartPosition = new Coordinate(WorldWidth, StatsHeight);
        private static Coordinate LogStartPosition = new Coordinate(0, WorldHeight);
        private const int MaxLogRows = LogHeight - 2;
        private static List<string> LogHistory = new List<string>(Enumerable.Repeat(string.Empty, MaxLogRows));

        public static void DrawUI()
        {
            var worldWindow = CreateFrame("World", WorldWidth, WorldHeight);
            var statsWindow = CreateFrame("Stats", StatsWidth, StatsHeight);
            var inventoryWindow = CreateFrame("Inventory", InventoryWidth, InventoryHeight);
            var logWindow = CreateFrame("Log", LogWidth, LogHeight);
            DrawFrame(worldWindow, WorldStartPosition);
            DrawFrame(statsWindow, StatsStartPosition);
            DrawFrame(inventoryWindow, InventoryStartPosition);
            DrawFrame(logWindow, LogStartPosition);
        }

        public static void DrawInventory(string[] items)
        {
            Draw(items, InventoryStartPosition, InventoryWidth, InventoryHeight);
        }

        public static void DrawStats(string[] stats)
        {
            Draw(stats, StatsStartPosition, StatsWidth, StatsHeight);
        }

        public static void LogMessage(params string[] messages)
        {
            LogHistory.RemoveRange(0, messages.Length);
            LogHistory.AddRange(messages);
            Draw(LogHistory.ToArray(), LogStartPosition, LogWidth, LogHeight);
        }

        public static void DrawEntity(Entity entity)
        {
            if (entity is Player player)
            {
                SetCursorPosition(player.PreviousPosition);
                Console.Write(EmptySymbol);
            }
            SetCursorPosition(entity.Position);
            Console.ForegroundColor = entity.Color;
            Console.Write(entity.Symbol);
        }

        private static void Draw(string[] messages, Coordinate startPosition, int width, int height)
        {
            var maxMessageWidth = width - 4;
            var maxMessageRows = height - 2;

            // truncate if messages are too wide
            // add padding to overwrite old stuff
            messages = messages
                .Select(s => s.Substring(0, s.Length > maxMessageWidth ? maxMessageWidth : s.Length).PadRight(maxMessageWidth))
                .ToArray();

            for (int i = 0; i < maxMessageRows; i++)
            {
                Console.SetCursorPosition(startPosition.X + 2, startPosition.Y + 1 + i);

                // we always draw all rows. draw empty row if there's no more messages
                var message = i >= messages.Length ? string.Empty.PadRight(maxMessageWidth) : messages[i];
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(message);
            }
        }

        // Create frames by a set width and height along with a name
        private static string[] CreateFrame(string name, int frameWidth, int frameHeight)
        {
            string[] frame = new string[frameHeight];
            var topRowTemplate = "╔═n╗";
            var middleRowTemplate = "║..║";
            var bottomRowTemplate = "╚══╝";
            int innerWidth = frameWidth - 2;
            int innerHeight = frameHeight - 2;

            // Create top row
            frame[0] = topRowTemplate.Replace("n", name.ToUpper().PadRight(innerWidth - 1, '═'));

            // Create middle ROWS
            middleRowTemplate = middleRowTemplate.Replace("..", string.Concat(Enumerable.Repeat(' ', innerWidth)));
            for (int i = 1; i <= innerHeight; i++)
            {
                frame[i] = middleRowTemplate;
            }

            // Create bottom row
            frame[frameHeight - 1] = bottomRowTemplate.Replace("══", string.Concat(Enumerable.Repeat('═', innerWidth)));
            return frame;
        }

        private static void DrawFrame(string[] frame, Coordinate startPosition)
        {
            for (int i = 0; i < frame.Length; i++)
            {
                Console.SetCursorPosition(startPosition.X, startPosition.Y + i);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(frame[i]);
            }
        }

        private static void SetCursorPosition(Coordinate position)
        {
            Console.SetCursorPosition(position.X, position.Y);
        }
    }
}
