using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeLaOrientacionDelPJ : MonoBehaviour
{
    public GameObject otroPlayer;
    private bool tengoAlOtroPlayer;

    public void Init()
    {
        otroPlayer = GameObject.Find("ControladorDeEscenario").GetComponent<ControladorDeEscenario>().BuscandoPJContrario(GetComponent<DatosPersistentesDelPlayer>().playerNumber);
        tengoAlOtroPlayer = true;
        GetComponent<MovimientoGenerico>().enabled = true;
        GetComponent<EstadoEstar>().enabled = true;
    }

    private void Update()
    {
        //< 0 debe mirar a la derecha
        //> 0 debe mirar a la izquieda
        if (tengoAlOtroPlayer)
        {
            Vector2 diferencia = gameObject.transform.position - otroPlayer.transform.position;
            if (diferencia.x < 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (diferencia.x > 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }
}
