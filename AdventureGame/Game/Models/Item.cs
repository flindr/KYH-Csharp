using Game.Properties;
using System;

namespace Game.Models
{
    abstract class Item : Entity
    {
        public Stat Attribute { get; set; }
        public bool IsWearable;
        public bool IsConsumable;
        public abstract void Apply(Creature target);
    }

    class HealingPotion : Item
    {
        public HealingPotion(Coordinate position)
        {
            Name = Resources.HealingPotion;
            Symbol = ItemHelper.Symbol(ItemType.HealingPotion);
            Color = ConsoleColor.Green;
            Position = position;
            Attribute = new Stat(StatType.Health, 20);
            IsConsumable = true;
        } 

        public override void Apply(Creature target)
        {
            UI.LogMessage($"Using {Name} on {target.Name} healing for {Attribute.Amount}");
            target.ApplyStatChange(Attribute);
            UI.LogMessage($"{target.Name} has {target.Health} health left.");
        }
    }

    class Shuriken : Item
    {
        public Shuriken(Coordinate position)
        {
            Name = Resources.Shuriken;
            Symbol = ItemHelper.Symbol(ItemType.Shuriken);
            Color = ConsoleColor.Green;
            Position = position;
            Attribute = new Stat(StatType.Health, -20);
            IsConsumable = true;
        }

        public override void Apply(Creature target)
        {
            UI.LogMessage($"Casting {Name} on {target.Name} for {Math.Abs(Attribute.Amount)} damage");
            target.ApplyStatChange(Attribute);
            UI.LogMessage($"{target.Name} has {target.Health} health left.");
        }
    }

    class Trident : Item
    {
        public Trident(Coordinate position)
        {
            Name = Resources.Trident;
            Symbol = ItemHelper.Symbol(ItemType.Trident);
            Color = ConsoleColor.Green;
            Position = position;
            Attribute = new Stat(StatType.Strength, 5);
            IsWearable = true;
        }

        public override void Apply(Creature target)
        {
            UI.LogMessage($"Equipped {Name} on {target.Name}...increasing strength with the power of Poseidon for {Attribute.Amount}");
            target.ApplyStatChange(Attribute);
            UI.LogMessage($"{target.Name} now has a total of {target.Strength} strength.");
        }
    }
}
