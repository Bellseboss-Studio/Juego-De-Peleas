using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDeSonidosCliente : MonoBehaviour
{
    public void WooSound()
    {
        IManejadorDeSonidosDelJuego manejadorDeSonido = GameObject.Instantiate(new ManejadorDeSonidoConVWise());
        manejadorDeSonido.TocarCancion(EnumSonidosDelJuego.Punch);
    }
}
