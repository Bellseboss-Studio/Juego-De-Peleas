namespace ServiceLocator
{
    public interface IFactoryStats
    {
        StatsBase Create(string nameCharacter);
    }
}