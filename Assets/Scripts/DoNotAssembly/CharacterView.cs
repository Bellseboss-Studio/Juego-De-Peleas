using ServiceLocator;
using UnityEngine;

public abstract class CharacterView : MonoBehaviour
{
    [SerializeField] protected string nombre;
    public CharacterBase CharacterBase { get; protected set; }

    public void Start()
    {
        CreacionDePersonaje(ServiceLocatorImplement.Instancie.GetService<IFactoryStats>().Create(nombre));
    }

    public abstract void CreacionDePersonaje(StatsBase statsBase);
}