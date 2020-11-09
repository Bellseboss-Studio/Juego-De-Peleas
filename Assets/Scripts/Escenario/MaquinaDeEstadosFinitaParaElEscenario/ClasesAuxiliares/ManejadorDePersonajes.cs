
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDePersonajes : IManejadorDePersonaje, IGuardarPlayerElegibles, IObtenerReferenciaDeLosPlayer,IGuardarReferenciaDeLosPlayer
{
    private Dictionary<string, EstadisticasBase> personajesElegibles;
    private GameObject player1, player2;

    public void Installer(List<EstadisticasBase> personajesElegibles)
    {
        this.personajesElegibles = new Dictionary<string, EstadisticasBase>();
        foreach(EstadisticasBase personaje in personajesElegibles)
        {
            this.personajesElegibles.Add(personaje.GetType().Name, personaje);
        }
    }

    public EstadisticasBase PrimerPlayer()
    {
        //buscamos al primer player
        string personaje = ServiceLocator.Instancie.GetService<IObtenerData>().GetStringData("Player1");
        if (!personajesElegibles.TryGetValue(personaje, out var personajeElegido))
        {
            throw new PersonajeElegidoNoExisteException("el personaje " + personaje + " No existe como elegible");
        }

        return personajeElegido;
        
    }

    public EstadisticasBase SegundoPlayer()
    {
        //buscamos al primer player
        string personaje = ServiceLocator.Instancie.GetService<IObtenerData>().GetStringData("Player2");
        if (!personajesElegibles.TryGetValue(personaje, out var personajeElegido))
        {
            throw new PersonajeElegidoNoExisteException("el personaje " + personaje + " No existe como elegible");
        }

        return personajeElegido;
    }

    public void GuardarNombreDelPrimerPlayer(string nombreDelPrimerPlayer)
    {
        ServiceLocator.Instancie.GetService<IGuardarData>().SetStringData("Player1", nombreDelPrimerPlayer);
    }

    public void GuardarNombreDelSegundoPlayer(string nombreDelSegundoPlayer)
    {
        ServiceLocator.Instancie.GetService<IGuardarData>().SetStringData("Player2", nombreDelSegundoPlayer);
    }

    public void Player1(GameObject player)
    {
        this.player1 = player;
    }

    public void Player2(GameObject player)
    {
        this.player2 = player;
    }

    public GameObject Player1()
    {
        return this.player1;
    }

    public GameObject Player2()
    {
        return this.player2;
    }
}
