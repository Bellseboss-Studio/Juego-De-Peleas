using ServiceLocator;

public class BeanView : CharacterView
{
    public override void CreacionDePersonaje(StatsBase statsBase)
    {
        CharacterBase = new BeanCharacter(statsBase);
    }
}