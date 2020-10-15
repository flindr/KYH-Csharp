using System;

namespace Game.Models
{
    class Cat : Creature
    {
        public Cat(Coordinate position)
        : base(
                CreatureHelper.Type(CreatureType.Cat), 
                CreatureHelper.Symbol(CreatureType.Cat),
                ConsoleColor.Red,
                position, 40, 5)
        {

        }

        public override void UseSkill(Creature creature)
        {
            var attribute = GetAttribute(StatType.Strength);
            UI.LogMessage($"{Name} scratches you causing {attribute.Amount} damage.");
            creature.ApplyStatChange(new Stat(StatType.Health, -attribute.Amount));
            UI.LogMessage($"{creature.Name} has {creature.Health} health left.");
        }
    }
}
