using Assets.Scripts.ModuloSonidosDelJuego;
using Assets.Scripts.ModuloSonidosDelJuego.Exceptions;
using System.Collections.Generic;
using UnityEngine;

public class SonidosConfiguration : ScriptableObject
{
    [SerializeField] private SonidoParaSonar[] sonidos;
    private Dictionary<EnumSonidosDelJuego, SonidoParaSonar> listaDeSonidos;

    private void Awake()
    {
        listaDeSonidos = new Dictionary<EnumSonidosDelJuego, SonidoParaSonar>(sonidos.Length);
        foreach (var sonido in sonidos)
        {
            listaDeSonidos.Add(sonido.Id, sonido);
        }
    }

    public SonidoParaSonar GetSonidoPrefabById(EnumSonidosDelJuego id)
    {
        if (!listaDeSonidos.TryGetValue(id, out var powerUp))
        {
            throw new SonidoNoEncontradoException($"Sonido with id {id} does not exit");
        }
        return powerUp;
    }
}