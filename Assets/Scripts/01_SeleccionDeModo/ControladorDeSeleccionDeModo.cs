using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeSeleccionDeModo : MonoBehaviour
{
    public void DosJugadores()
    {
        Debug.Log("paso por aqui par ala pelea");
        SceneManager.LoadScene((int)IndicesDeEscenas.PELEA);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene((int)IndicesDeEscenas.INTRO);
    }
}
