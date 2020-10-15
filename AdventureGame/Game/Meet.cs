using Game.Models;
using System;

namespace Game
{
    enum MeetStatus
    {
        Win,
        Loss,
        InProgress
    }

    enum Action
    {
        Invalid = -1,
        UseSkill = 1,
        ViewBackpack = 2
    }

    public enum Target
    {
        Invalid = -1,
        Player = 1,
        Creature = 2,
    }

    static class Meet
    {
        private static Player Player;
        private static Creature Creature;

        public static MeetStatus Start(Player player, Creature creature)
        {
            Player = player;
            Player.CurrentTarget = creature;
            Creature = creature;

            UI.LogMessage($"You've stumbled upon a {Creature.Name.ToLower()}. It looks a bit aggressive...");

            while (GetMeetStatus() == MeetStatus.InProgress)
            {
                PlayerTurn();

                if (GetMeetStatus() == MeetStatus.InProgress)
                {
                    CreatureTurn();
                }
            }

            if (GetMeetStatus() == MeetStatus.Win)
            {
                UI.LogMessage("Nice fight :sunglassesemoji. Press aaaany key to continue.");
            }
            else if (GetMeetStatus() == MeetStatus.Loss)
            {
                UI.LogMessage("It was too strong :((((( Press aaaany key to continue.");
            }

            Console.ReadKey();
            return GetMeetStatus();
        }

        private static MeetStatus GetMeetStatus()
        {
            if (Player.Health <= 0)
            {
                return MeetStatus.Loss;
            }
            else if (Creature.Health <= 0)
            {
                return MeetStatus.Win;
            }

            return MeetStatus.InProgress;
        }

        private static void PlayerTurn()
        {
            Action action;
            do
            {
                UI.LogMessage("Select your action.");
                UI.LogMessage("1. Use skill.");
                UI.LogMessage("2. View backpack.");

                action = Enum.TryParse(Console.ReadKey().KeyChar.ToString(), out action) ? action : Action.Invalid;

                switch (action)
                {
                    case Action.UseSkill:
                        Player.UseSkill(Creature);
                        break;
                    case Action.ViewBackpack:
                        Player.ViewBackpack();
                        break;
                    default:
                        UI.LogMessage("Try again.");
                        break;
                }
            } while (action == Action.Invalid);
        }

        private static void CreatureTurn()
        {
            Creature.UseSkill(Player);
        }
    }
}
