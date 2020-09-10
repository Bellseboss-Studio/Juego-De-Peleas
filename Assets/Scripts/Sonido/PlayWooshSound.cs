using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWooshSound : MonoBehaviour
{
    [SerializeField] private IManejadorDeSonidosDelJuego manejador;

    public void PlayWoosh()
    {
        manejador.TocarCancion(EnumSonidosParaSonar.Woosh);
    }

}
