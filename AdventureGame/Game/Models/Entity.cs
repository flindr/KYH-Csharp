using System;

namespace Game.Models
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public Coordinate Position { get; protected set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
