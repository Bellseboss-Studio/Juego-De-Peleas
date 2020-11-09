
using System.Collections.Generic;

public interface IManejadorDePersonaje
{
    void Installer(List<EstadisticasBase> personajesElegibles);
    EstadisticasBase PrimerPlayer();
    EstadisticasBase SegundoPlayer();
}