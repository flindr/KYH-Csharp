namespace Game.Models
{
    public class Stat
    {
        public StatType Type { get; set; }
        public int Amount { get; set; }

        public Stat(StatType type, int amount)
        {
            Type = type;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Type}: {Amount}";
        }
    }

    public enum StatType
    {
        Strength,
        Health,
        Intelligence,
    }
}
