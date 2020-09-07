using UnityEngine;
using System.Collections;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DatosPersistentesDelPlayer : MonoBehaviour
{
    [Range(1, 2)]
    public int playerNumber;
    [SerializeField]
    public bool FueGolpeado;
    //Propiedades para los combos
    [SerializeField]
    private TextMeshProUGUI letrero;
    [SerializeField]
    private int cantidadDeGolpes;
    InputManager im;

    public TextMeshProUGUI Letrero { get => letrero; set => letrero = value; }

    public int CantidadDeGolpes { get => cantidadDeGolpes; set => cantidadDeGolpes = value; }
    private void Start()
    {
        im = GameObject.Find("ControladorDeEscenario").GetComponent<InputManager>();
    }
    public void AumentarCantidadDeGolpes()
    {
        cantidadDeGolpes++;
    }

    public void MostrarLetreroDeCombos()
    {
        letrero.gameObject.SetActive(true);
        letrero.text = string.Format("Combo {0}", cantidadDeGolpes);
    }
    public void OcultarLetreroDeCombos()
    {
        letrero.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (im.SeprecionoElBoton(InputDefinidosParaElJuego.Start))
        {
            SceneManager.LoadScene("Peleas");
        }
    }

    private void OnMouseDown()
    {
        
    }


}
