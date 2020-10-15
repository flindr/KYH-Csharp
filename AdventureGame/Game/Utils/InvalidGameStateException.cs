using System;

namespace Game.Models
{
    class InvalidGameStateException : Exception
    {
        public InvalidGameStateException(string message)
        : base(message)
        {

        }
    }
}
