using System;
using UnityEngine;

public class ControllerCharacterSelectLogic
{
    private IControllerCharacterSelectMono controllerCharacterSelectMono;
    private GameObject[,] listaDePersonajes;
    private int ancho, alto;
    private InputManager input;
    private bool faltaUnStartMasParaJugar;

    public float AumentoFlotante { get; set; }

    public ControllerCharacterSelectLogic(IControllerCharacterSelectMono mono, InputManager inputManager)
    {
        controllerCharacterSelectMono = mono;
        input = inputManager;
    }

    public void Init(int ancho, int alto, GameObject[] gamesObjects)
    {
        this.ancho = ancho;
        this.alto = alto;
        listaDePersonajes = new GameObject[this.ancho, this.alto];
        for (var i = 0; i < ancho; i++)
        {
            for (var a = 0; a < alto; a++)
            {
                listaDePersonajes[i, a] = gamesObjects[i + a];
            }
        }
    }

    public void VerificandoQueElPlayerSeHayaMovido(IPlayerJuegoDePelea player)
    {
        if (!player.SeSelecciono)
        {
            if (input.SeMovioHorizontalmente(player.player) != 0)
            {
                if (input.SeMovioHorizontalmente(player.player) > 0)
                {
                    player.x += player.x > ancho ? 0 : AumentoFlotante;
                }
                else if (input.SeMovioHorizontalmente(player.player) < 0)
                {
                    player.x -= player.x < 1 ? 0 : AumentoFlotante;
                }
            }
            else
            {
                player.x = player.x < 1 ? 1 : player.x > ancho ? ancho : (int)player.x;
                SeleccionarObjectoDelCampoParaMostrarleAlgo(player);
            }

            if (input.SeMovioVerticalmente(player.player) != 0)
            {
                if (input.SeMovioVerticalmente(player.player) > 0)
                {
                    player.y += player.y > alto ? 0 : AumentoFlotante;
                }
                else if (input.SeMovioVerticalmente(player.player) < 0)
                {
                    player.y -= player.y < 1 ? 0 : AumentoFlotante;
                }
            }
            else
            {
                player.y = player.y < 1 ? 1 : player.y > alto ? alto : (int)player.y;
                SeleccionarObjectoDelCampoParaMostrarleAlgo(player);
            }
        }

        InputDefinidosParaElJuego botonPrecionado = player.player == 1 ? InputDefinidosParaElJuego.Start : InputDefinidosParaElJuego.Start_p2;
        if (input.SeUndioElBoton(botonPrecionado))
        {
            player.SeSelecciono = !player.SeSelecciono;
            if (player.SeSelecciono)
            {
                player.personajeElegido = BuscarPersonaje(player);
            }
            if (!faltaUnStartMasParaJugar)
            {
                controllerCharacterSelectMono.CargarLaEscenaDePelea();
            }
        }
    }

    public void LosDosPlayerSeleccionaron(IPlayerJuegoDePelea player1, IPlayerJuegoDePelea player2)
    {
        if(player1.SeSelecciono && player2.SeSelecciono)
        {
            controllerCharacterSelectMono.UnStartMasParaComenzar();
            faltaUnStartMasParaJugar = false;
        }
        else
        {
            faltaUnStartMasParaJugar = true;
        }
    }

    private void SeleccionarObjectoDelCampoParaMostrarleAlgo(IPlayerJuegoDePelea player)
    {
        player.gameObject.gameObject.transform.parent = BuscarPersonaje(player).transform;
        player.gameObject.gameObject.transform.localPosition = Vector2.zero;
    }

    private GameObject BuscarPersonaje(IPlayerJuegoDePelea player)
    {
        int x, y;
        y = (int)(player.y < 1 ? 1 : player.y > alto ? alto : player.y);
        x = (int)(player.x < 1 ? 1 : player.x > ancho ? ancho : player.x);
        x -= 1;
        y -= 1;
        x = x < 0 ? 0 : x;
        y = y < 0 ? 0 : y;
        return listaDePersonajes[x, y];
    }
}