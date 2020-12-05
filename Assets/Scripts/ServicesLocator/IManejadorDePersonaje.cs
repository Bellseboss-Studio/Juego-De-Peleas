
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator
{
    public interface IManejadorDePersonaje
    {
        void Installer(List<CharacterBase> personajesElegibles);
        CharacterBase PrimerPlayer();
        CharacterBase SegundoPlayer();
    }
}