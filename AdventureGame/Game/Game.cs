using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    enum GameStatus
    {
        Win,
        Loss,
        InProgress
    }

    static class Game
    {
        public const int WindowWidth = 80, WindowHeight = 30;
        static GameStatus Status = GameStatus.InProgress;
        private static readonly Player Player = new Player(new Coordinate(10, 15));
        private static List<Entity> Entities;

        public static void Start()
        {
            Initialize();

            RunGameLoop();
        }

        private static void Initialize()
        {
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.SetBufferSize(WindowWidth, WindowHeight);
            Console.Title = "Game :D";
            Console.CursorVisible = false;

            Entities = Randomizer.GenerateEntities();

            UI.DrawUI();
            UI.DrawStats(Player.Attributes.Select(stat => stat.ToString()).ToArray());
            UI.DrawEntity(Player);
            Entities.ForEach(entity => UI.DrawEntity(entity));
        }

        private static void RunGameLoop()
        {
            while (Status == GameStatus.InProgress)
            {
                try
                {
                    Player.Move();

                    HandleCollision();

                    UI.DrawEntity(Player);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            GameOver();
        }

        private static void HandleCollision()
        {
            var entity = Entities.SingleOrDefault(entity => entity.Position == Player.Position);
            
            if (entity is Creature creature)
            {
                if (Meet.Start(Player, creature) == MeetStatus.Loss)
                    Status = GameStatus.Loss;

            }
            else if (entity is Item item)
            {
                Player.Pickup(item);
            }

            Entities.Remove(entity);
        }

        private static void GameOver()
        {
            if (Status == GameStatus.Win)
            {
                UI.LogMessage("Noooooooise!");
            }
            else
            {
                UI.LogMessage("Sry :(");
            }

            UI.LogMessage("Press any key to end the game.");
        }
    }
}
