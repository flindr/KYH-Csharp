using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    abstract class Creature : Entity
    {
        public List<Stat> Attributes { get; set; }
        public int Health => Attributes.SingleOrDefault(attribute => attribute.Type == StatType.Health).Amount;
        public int Strength => Attributes.SingleOrDefault(attribute => attribute.Type == StatType.Strength).Amount;

        protected Creature(string name, char symbol, ConsoleColor color, Coordinate position, int healthAmount, int strengthAmount)
        {
            Name = name;
            Symbol = symbol;
            Color = color;
            Position = position;
            Attributes = new List<Stat>
            {
                new Stat(StatType.Health, healthAmount),
                new Stat(StatType.Strength, strengthAmount),
            };
        }

        public abstract void UseSkill(Creature creature);

        public Stat GetAttribute(StatType type)
        {
            var attribute = Attributes.SingleOrDefault(attribute => attribute.Type == type);
            if (attribute == null)
                throw new InvalidGameStateException($"StatType {type} does not exist on creature {Name}.");
            return attribute;
        }

        public void ApplyStatChange(Stat statChange)
        {
            var attribute = GetAttribute(statChange.Type);
            attribute.Amount = (attribute.Amount + statChange.Amount) < 0 ? 0 : attribute.Amount + statChange.Amount;
        }
    }
}
