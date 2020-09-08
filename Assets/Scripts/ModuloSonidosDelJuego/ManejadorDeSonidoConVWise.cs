using Assets.Scripts.ModuloSonidosDelJuego;
using UnityEngine;

public class ManejadorDeSonidoConVWise : MonoBehaviour, IManejadorDeSonidosDelJuego
{
    [SerializeField] SonidosConfiguration configuracionSonido;
    public void TocarCancion(EnumSonidosDelJuego sonido)
    {
        //implementamos una Factoria
        SonidosFacotry factoriaDeSonidos = new SonidosFacotry(GameObject.Instantiate(configuracionSonido));
        SonidoParaSonar sonidoPorSonar = factoriaDeSonidos.Create(sonido);
        sonidoPorSonar.Evento.Post(gameObject);
    }
}
