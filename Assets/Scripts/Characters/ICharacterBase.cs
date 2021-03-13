using UnityEngine;
using System.Collections;
using ServiceLocator;

public abstract class CharacterBase
{
    public StatsBase StatsBase { get; private set; }
    public CharacterBase(StatsBase baseStat)
    {
        StatsBase = baseStat;
    }
}
