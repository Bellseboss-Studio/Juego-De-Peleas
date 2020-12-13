
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator
{
    public class ManejadorDePersonajes : IManejadorDePersonaje, IObtenerReferenciaDeLosPlayer, IGuardarReferenciaDeLosPlayer
    {
        private Dictionary<string, CharacterBase> personajesElegibles;
        private GameObject player1, player2;

        public void Installer(List<CharacterBase> personajesElegibles)
        {
            this.personajesElegibles = new Dictionary<string, CharacterBase>();
            foreach(CharacterBase personaje in personajesElegibles)
            {
                this.personajesElegibles.Add(personaje.StatsBase.Name, personaje);
            }
        }

        public CharacterBase PrimerPlayer()
        {
            //buscamos al primer player
            string personaje = ServiceLocatorImplement.Instancie.GetService<IObtenerData>().GetStringData("Player1");
            if (!personajesElegibles.TryGetValue(personaje, out var personajeElegido))
            {
                throw new SelecterCharacterDoNotExistException("el personaje " + personaje + " No existe como elegible");
            }

            return personajeElegido;
        
        }

        public CharacterBase SegundoPlayer()
        {
            //buscamos al primer player
            string personaje = ServiceLocatorImplement.Instancie.GetService<IObtenerData>().GetStringData("Player2");
            if (!personajesElegibles.TryGetValue(personaje, out var personajeElegido))
            {
                throw new SelecterCharacterDoNotExistException("el personaje " + personaje + " No existe como elegible");
            }

            return personajeElegido;
        }

        public void GuardarNombreDelPrimerPlayer(string nombreDelPrimerPlayer)
        {
            ServiceLocatorImplement.Instancie.GetService<IGuardarData>().SetStringData("Player1", nombreDelPrimerPlayer);
        }

        public void GuardarNombreDelSegundoPlayer(string nombreDelSegundoPlayer)
        {
            ServiceLocatorImplement.Instancie.GetService<IGuardarData>().SetStringData("Player2", nombreDelSegundoPlayer);
        }

        public void Player1(GameObject player)
        {
            player1 = player;
        }

        public void Player2(GameObject player)
        {
            player2 = player;
        }

        public GameObject Player1()
        {
            return player1;
        }

        public GameObject Player2()
        {
            return player2;
        }
    }
}