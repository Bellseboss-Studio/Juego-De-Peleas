using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCharacterSelectMono : MonoBehaviour
{
    public GameObject[,] listaDePersonajes;
    [SerializeField] private int ancho, alto;
    [SerializeField] private InputManager input;
    [SerializeField] private float indicePlayer1X, indicePlayer1Y;
    [SerializeField] private float indicePlayer2X, indicePlayer2Y;
    [SerializeField] private float aumentoFlotante;
    [SerializeField] private Image selectorPlayer1, selectorPlayer2;

    private void Start()
    {
        listaDePersonajes = new GameObject[ancho, alto];
        for (var i = 0; i < ancho; i++)
        {
            for(var a = 0; a < alto; a++)
            {
                listaDePersonajes[i, a] = GameObject.FindGameObjectsWithTag("characterSelector")[i + a];
                Debug.Log(listaDePersonajes[i, a] + "i " + i + " a " + a);
            }
        }
    }

    private void Update()
    {
        if(input.SeMovioHorizontalmente(1) != 0)
        {
            Debug.Log(input.SeMovioHorizontalmente(1) + "<----------input.SeMovioHorizontalmente(1)");
            if (input.SeMovioHorizontalmente(1) > 0)
            {
                indicePlayer1X += indicePlayer1X > ancho ? 0 : aumentoFlotante;
            }
            else if (input.SeMovioHorizontalmente(1) < 0)
            {
                indicePlayer1X -= indicePlayer1X < 1 ? 0 : aumentoFlotante;
            }
        }
        else
        {
            indicePlayer1X = indicePlayer1X < 1 ? 1 : indicePlayer1X > ancho ? ancho : (int)indicePlayer1X;
            SeleccionarObjectoDelCampoParaMostrarleAlgo((int)indicePlayer1X, (int)indicePlayer1Y);
        }

        if (input.SeMovioVerticalmente(1) != 0)
        {
            Debug.Log(input.SeMovioVerticalmente(1) + "<----------input.SeMovioVerticalmente(1)");
            if (input.SeMovioVerticalmente(1) > 0)
            {
                indicePlayer1Y += indicePlayer1Y > alto ? 0 : aumentoFlotante;
            }
            else if (input.SeMovioVerticalmente(1) < 0)
            {
                indicePlayer1Y -= indicePlayer1Y < 1 ? 0 : aumentoFlotante;
            }
        }
        else
        {
            indicePlayer1Y = indicePlayer1Y < 1 ? 1 : indicePlayer1Y > alto ? alto : (int)indicePlayer1Y;
            SeleccionarObjectoDelCampoParaMostrarleAlgo((int)indicePlayer1X, (int)indicePlayer1Y);
        }

        if (input.SeMovioHorizontalmente(2) != 0)
        {
            Debug.Log(input.SeMovioHorizontalmente(2) + "<----------input.SeMovioHorizontalmente(2)");
            if (input.SeMovioHorizontalmente(2) > 0)
            {
                indicePlayer2X += indicePlayer2X > ancho ? 0 : aumentoFlotante;
            }
            else if (input.SeMovioHorizontalmente(1) < 0)
            {
                indicePlayer2X -= indicePlayer2X < 1 ? 0 : aumentoFlotante;
            }
        }
        else
        {
            indicePlayer2X = indicePlayer2X < 1 ? 1 : indicePlayer2X > ancho ? ancho : (int)indicePlayer2X;
            SeleccionarObjectoDelCampoParaMostrarleAlgo((int)indicePlayer2X, (int)indicePlayer2Y);
        }

        if (input.SeMovioHorizontalmente(2) != 0)
        {
            if (input.SeMovioVerticalmente(2) > 0)
            {
                indicePlayer2Y += aumentoFlotante;
            }
            else if (input.SeMovioVerticalmente(2) < 0)
            {
                indicePlayer2Y -= aumentoFlotante;
            }
        }
        else
        {
            indicePlayer2Y = indicePlayer2Y < 1 ? 1 : indicePlayer2Y > alto ? alto : (int)indicePlayer2Y;
            SeleccionarObjectoDelCampoParaMostrarleAlgo((int)indicePlayer2X, (int)indicePlayer2Y);
        }
    }

    private void SeleccionarObjectoDelCampoParaMostrarleAlgo(int x, int y)
    {
        y = y < 1 ? 1 : y > alto ? alto : y;
        x = x < 1 ? 1 : x > ancho ? ancho : x;
        x -= 1;
        y -= 1;
        x = x < 0 ? 0 : x;
        y = y < 0 ? 0 : y;
        //referencia a donde debe de estar la imagen
        selectorPlayer1.gameObject.transform.parent = listaDePersonajes[x, y].transform;
    }
}
