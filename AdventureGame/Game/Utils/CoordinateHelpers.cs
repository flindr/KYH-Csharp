using System;

namespace Game.Models
{
    static class CoordinateHelpers
    {
        public static Coordinate GetNewPosition(Coordinate playerPosition, ConsoleKeyInfo key)
        {
            Coordinate newPosition = playerPosition;

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    newPosition.X--;
                    break;
                case ConsoleKey.UpArrow:
                    newPosition.Y--;
                    break;
                case ConsoleKey.RightArrow:
                    newPosition.X++;
                    break;
                case ConsoleKey.DownArrow:
                    newPosition.Y++;
                    break;
            }

            return IsValid(newPosition) ? newPosition : playerPosition;
        }

        public static bool IsValid(Coordinate position)
        {
            if (position.X <= 0 || position.Y <= 0 || position.X >= UI.WorldWidth - 1 || position.Y >= UI.WorldHeight - 1)
                return false;
            else
                return true;
        }
    }
}
