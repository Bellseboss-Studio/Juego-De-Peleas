using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerCharacterSelectMono : MonoBehaviour, IControllerCharacterSelectMono
{
    [SerializeField] private int ancho, alto;
    [SerializeField] private InputManager input;
    [SerializeField] private float indicePlayer1X, indicePlayer1Y;
    [SerializeField] private float indicePlayer2X, indicePlayer2Y;
    [SerializeField] private float aumentoFlotante;
    [SerializeField] private GameObject selectorPlayer1, selectorPlayer2;
    private ControllerCharacterSelectLogic logica;
    IPlayerJuegoDePelea player1, player2;

    private void Start()
    {
        player1 = new Player
        {
            player = 1,
            x = indicePlayer1X,
            y = indicePlayer1Y,
            gameObject = selectorPlayer1
        };

        player2 = new Player
        {
            player = 2,
            x = indicePlayer1X,
            y = indicePlayer1Y,
            gameObject = selectorPlayer2
        };

        logica = new ControllerCharacterSelectLogic(this, input)
        {
            AumentoFlotante = aumentoFlotante
        };
        logica.Init(ancho, alto, GameObject.FindGameObjectsWithTag("characterSelector"));
    }

    private void Update()
    {
        logica.VerificandoQueElPlayerSeHayaMovido(player1);
        logica.VerificandoQueElPlayerSeHayaMovido(player2);
        logica.LosDosPlayerSeleccionaron(player1, player2);
    }

    public GameObject[] GetGameObjects()
    {
        return GameObject.FindGameObjectsWithTag("characterSelector");
    }

    public void UnStartMasParaComenzar()
    {
        //TODO se coloca en la UI algo que indique que falta un start
    }

    public void CargarLaEscenaDePelea()
    {
        SceneManager.LoadScene(3);
    }
}
