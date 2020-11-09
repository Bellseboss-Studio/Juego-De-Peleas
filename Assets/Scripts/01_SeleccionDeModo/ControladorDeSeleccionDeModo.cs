using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeSeleccionDeModo : MonoBehaviour
{
    public void DosJugadores()
    {
        Debug.Log("paso por aqui par ala pelea");
        ServiceLocator.Instancie.GetService<IGuardarData>().SetStringData("Player1","Cyborg");
        ServiceLocator.Instancie.GetService<IGuardarData>().SetStringData("Player2", "Cyborg");
        SceneManager.LoadScene((int)IndicesDeEscenas.PELEA);

    }

    public void Reiniciar()
    {
        SceneManager.LoadScene((int)IndicesDeEscenas.INTRO);
    }
}
