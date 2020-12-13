using ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeSeleccionDeModo : MonoBehaviour
{
    public void DosJugadores()
    {
        SceneManager.LoadScene((int)IndicesDeEscenas.SELECCION_DE_PERSONAJE);

    }

    public void Reiniciar()
    {
        SceneManager.LoadScene((int)IndicesDeEscenas.INTRO);
    }
}
