
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDePersonajes : IManejadorDePersonaje, IObtenerReferenciaDeLosPlayer,IGuardarReferenciaDeLosPlayer
{
    private Dictionary<string, BasePlayer> personajesElegibles;
    private GameObject player1, player2;

    public void Installer(List<BasePlayer> personajesElegibles)
    {
        this.personajesElegibles = new Dictionary<string, BasePlayer>();
        foreach(BasePlayer personaje in personajesElegibles)
        {
            this.personajesElegibles.Add(personaje.GetType().Name, personaje);
        }
    }

    public BasePlayer PrimerPlayer()
    {
        //buscamos al primer player
        string personaje = ServiceLocator.Instancie.GetService<IObtenerData>().GetStringData("Player1");
        if (!personajesElegibles.TryGetValue(personaje, out var personajeElegido))
        {
            throw new PersonajeElegidoNoExisteException("el personaje " + personaje + " No existe como elegible");
        }

        return personajeElegido;
        
    }

    public BasePlayer SegundoPlayer()
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
