using ServiceLocator;
using UnityEngine;

public class ZpoppetView : CharacterView
{
    public override void CreacionDePersonaje(StatsBase statsBase)
    {
        CharacterBase = new ZpoppetCharacter(statsBase);
    }
}