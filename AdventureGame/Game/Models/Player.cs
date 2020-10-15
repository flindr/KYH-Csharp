using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    class Player : Creature
    {
        public Inventory Inventory { get; private set; }
        public List<Item> Equipment { get; private set; }
        public Coordinate PreviousPosition { get; private set; }
        public Creature CurrentTarget { get; set; }

        public Player(Coordinate position) : base(CreatureHelper.Type(CreatureType.Player),
                CreatureHelper.Symbol(CreatureType.Player), ConsoleColor.Blue, position, 50, 10)
        {
            Inventory = new Inventory();
            Equipment = new List<Item>();
            PreviousPosition = position;
        }

        public void UpdatePosition(Coordinate newPosition)
        {
            PreviousPosition = Position;
            Position = newPosition;
        }

        public void ViewBackpack()
        {
            if (Inventory.Count == 0)
            {
                UI.LogMessage("Backpack is empty. Returning...");
            }
            else
            {
                Item item = SelectItem();

                Use(item);
            }
        }

        public void Move()
        {
            UI.LogMessage("Move using the arrow keys!");
            var key = Console.ReadKey();
            UpdatePosition(CoordinateHelpers.GetNewPosition(Position, key));
        }

        private void Use(Item item)
        {
            if(item.IsWearable)
            {
                Equipment.Add(item);
                item.Apply(this);
            }
            else
            {
                Target target;
                do
                {
                    UI.LogMessage($"Use on 1. Yourself 2. {CurrentTarget.Name}");
                    target = Enum.TryParse(Console.ReadKey().KeyChar.ToString(), out target) ? target : Target.Invalid;

                    if (target != Target.Invalid)
                    {
                        item.Apply(target == Target.Creature ? CurrentTarget : this);
                    }
                    else
                    {
                        UI.LogMessage($"You must select either yourself or the {CurrentTarget.Name}. Try again.");
                    }
                } while (target == Target.Invalid);
            }

            Inventory.Remove(item);
            UI.DrawInventory(Inventory.ToString());
            UI.DrawStats(Attributes.Select(stat => stat.ToString()).ToArray());
        }

        private Item SelectItem()
        {
            Item item = null;
            while (item == null)
            {
                UI.LogMessage("Select item.");
                for (int i = 0; i < Inventory.Count; i++)
                {
                    UI.LogMessage($"{i + 1}. {Inventory[i].Name}");
                }

                int itemIndex = int.TryParse(Console.ReadKey().KeyChar.ToString(), out itemIndex) ? --itemIndex : -1;
                item = Inventory.ElementAtOrDefault(itemIndex);
            }
            return item;
        }

        public override void UseSkill(Creature creature)
        {
            var attribute = GetAttribute(StatType.Strength);
            UI.LogMessage($"You deal {attribute.Amount} of damage.");
            creature.ApplyStatChange(new Stat(StatType.Health, -attribute.Amount));
            UI.LogMessage($"{creature.Name} has {creature.Health} health left.");
        }

        public Item Pickup(Item item)
        {
            if (item == null)
                throw new InvalidGameStateException("Item is null. Item should not be null.");

            Inventory.Add(item);
            UI.LogMessage($"You picked up {item.Name}. Press any key to continue :O");
            UI.DrawInventory(Inventory.Select(item => item.ToString()).ToArray());

            Console.ReadKey();
            return item;
        }
    }
}
