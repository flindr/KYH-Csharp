using Game.Properties;
using System;

namespace Game.Models
{
    enum CreatureType
    {
        Player,
        Squid,
        Cat,
        Golem,
    }

    enum ItemType
    {
        HealingPotion,
        Shuriken,
        Trident
    }

    static class CreatureHelper
    {
        public static string Type(CreatureType creature)
        {
            switch (creature)
            {
                case CreatureType.Player:
                    return Resources.Player;
                case CreatureType.Squid:
                    return Resources.Squid;
                case CreatureType.Cat:
                    return Resources.Cat;
                case CreatureType.Golem:
                    return Resources.Golem;
                default:
                    throw new NotImplementedException();
            }
        }

        public static char Symbol(CreatureType creature)
        {
            switch (creature)
            {
                case CreatureType.Player:
                    return '●';
                case CreatureType.Squid:
                    return 'ᴥ';
                case CreatureType.Cat:
                    return '₷';
                case CreatureType.Golem:
                    return 'g';
                default:
                    throw new NotImplementedException();
            }
        }
    }

    static class ItemHelper
    {
        public static string Type(ItemType item)
        {
            switch (item)
            {
                case ItemType.HealingPotion:
                    return Resources.HealingPotion;
                case ItemType.Shuriken:
                    return Resources.Shuriken;
                case ItemType.Trident:
                    return Resources.Trident;
                default:
                    throw new NotImplementedException();
            }
        }

        public static char Symbol(ItemType item)
        {
            switch (item)
            {
                case ItemType.HealingPotion:
                    return '℗';
                case ItemType.Shuriken:
                    return '҉';
                case ItemType.Trident:
                    return 'Ψ';
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
