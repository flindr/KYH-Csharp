using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    static class Randomizer
    {
        private static readonly Random random = new Random();

        public static List<Entity> GenerateEntities()
        {
            var entities = new List<Entity>();
            for (int i = 0; i < 10; i++)
            {
                var entity = RandomizeCreature();
                entities.TryAdd(entity);
            }

            for (int i = 0; i < 10; i++)
            {
                var entity = RandomizeItem();
                entities.TryAdd(entity);
            }
            
            return entities;
        }

        private static Entity RandomizeCreature()
        {
            var creature = (CreatureType) random.Next(1, (int)CreatureType.Golem + 1);
            switch (creature)
            {
                case CreatureType.Squid:
                    return new Squid(RandomCoordinate());
                case CreatureType.Cat:
                    return new Cat(RandomCoordinate());
                case CreatureType.Golem:
                    return new Cat(RandomCoordinate());
                default:
                    throw new NotImplementedException();
            }
        }

        private static Entity RandomizeItem()
        {
            var creature = (ItemType)random.Next(0, (int)ItemType.Trident + 1);
            switch (creature)
            {
                case ItemType.HealingPotion:
                    return new HealingPotion(RandomCoordinate());
                case ItemType.Shuriken:
                    return new Shuriken(RandomCoordinate());
                case ItemType.Trident:
                    return new Trident(RandomCoordinate());
                default:
                    throw new NotImplementedException();
            }
        }

        private static Coordinate RandomCoordinate()
        {
            return new Coordinate(
                        random.Next(1, UI.WorldWidth - 1),
                        random.Next(1, UI.WorldHeight - 1));
        }

        // don't add if position is already taken
        private static void TryAdd(this List<Entity> entities, Entity entity)
        {
            if(!entities.Any(e => e.Position == entity.Position))
            {
                entities.Add(entity);
            } 
        }
    }
}
