
using System.Collections.Generic;
using UnityEngine;

public interface IManejadorDePersonaje
{
    void Installer(List<BasePlayer> personajesElegibles);
    BasePlayer PrimerPlayer();
    BasePlayer SegundoPlayer();
}