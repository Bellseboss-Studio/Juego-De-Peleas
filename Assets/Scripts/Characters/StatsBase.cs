using System;

namespace ServiceLocator
{
    public class StatsBase
    {
        public double Life { get; private set; }
        public string Name { get; private set; }

        public StatsBase(double life, string name)
        {
            Life = life;
            Name = name;
        }

        public StatsBase(StatsBaseJson statsBaseJson)
        {
            Life = statsBaseJson.Life;
            Name = statsBaseJson.Name;
        }

        public bool Compare(StatsBase statsBase)
        {
            return Equals(statsBase);
        }
    }
}