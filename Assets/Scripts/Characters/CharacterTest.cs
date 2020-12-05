namespace ServiceLocator
{
    public class CharacterTest : CharacterBase
    {

        public CharacterTest(StatsBase statsBase)
        {
            StatsBase = statsBase;
        }
        
        public StatsBase StatsBase { get; }
    }
}