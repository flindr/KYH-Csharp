using System;

namespace Game.Models
{
    class Squid : Creature
    {
        public Squid(Coordinate position)
        : base(
                CreatureHelper.Type(CreatureType.Squid), 
                CreatureHelper.Symbol(CreatureType.Squid),
                ConsoleColor.Red,
                position, 20, 5)
        {

        }

        public override void UseSkill(Creature creature)
        {
            var attribute = GetAttribute(StatType.Strength);
            UI.LogMessage($"{Name} moonwalks into you causing {attribute.Amount} damage.");
            creature.ApplyStatChange(new Stat(StatType.Health, -attribute.Amount));
            UI.LogMessage($"{creature.Name} has {creature.Health} health left.");
        }
    }
}
