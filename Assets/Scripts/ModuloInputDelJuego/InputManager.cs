using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private List<InputGame> listaDeIputs;
    private Dictionary<InputDefinidosParaElJuego, InputGame> diccionarioDeControles;
    public bool isJoitick;

    private void Awake()
    {
        diccionarioDeControles = new Dictionary<InputDefinidosParaElJuego, InputGame>();
        foreach (InputGame ig in listaDeIputs)
        {
            diccionarioDeControles.Add(ig.Id, ig);
        }
    }

    public void CambiarJoistickTeclado(TextMeshProUGUI texto)
    {
        isJoitick = !isJoitick;
        if (isJoitick)
        {
            texto.text = "Se Juega con Control";
        }
        else
        {
            texto.text = "Se Juega con Teclado";
        }
        texto.text += " preciona para cambiar";
    }

    public bool SeprecionoElBoton(InputDefinidosParaElJuego input)
    {
        InputGame ig;
        diccionarioDeControles.TryGetValue(input, out ig);
        if (isJoitick)
        {
            return Input.GetKey(ig.Joistick);
        }
        else
        {
            return Input.GetKey(ig.Keyboard);
        }
    }

    public bool SeUndioElBoton(InputDefinidosParaElJuego input)
    {
        InputGame ig;
        diccionarioDeControles.TryGetValue(input, out ig);
        if (isJoitick)
        {
            return Input.GetKeyDown(ig.Joistick);
        }
        else
        {
            return Input.GetKeyDown(ig.Keyboard);
        }
    }

    public KeyCode BotonPrecionado(InputDefinidosParaElJuego input)
    {
        InputGame ig;
        diccionarioDeControles.TryGetValue(input, out ig);
        if (isJoitick)
        {
            return ig.Joistick;
        }
        else
        {
            return ig.Keyboard;
        }
    }

    public float SeMovioHorizontalmente(int playerNumber)
    {
        return Input.GetAxis("Horizontal_Player" + ConstruirNombreDeAxis(playerNumber));
    }

    public float SeMovioVerticalmente(int playerNumber)
    {
        return Input.GetAxis("Vertical_Player"+ ConstruirNombreDeAxis(playerNumber));
    }

    private string ConstruirNombreDeAxis(int playerNumber)
    {
        string nombreBase = "";
        nombreBase += isJoitick ? "_joi" : "_key";
        nombreBase += playerNumber.ToString();
        return nombreBase;
    }
}
