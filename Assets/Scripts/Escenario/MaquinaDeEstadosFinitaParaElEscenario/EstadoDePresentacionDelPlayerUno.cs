using ServiceLocator;
using System;
using UnityEngine;

public class EstadoDePresentacionDelPlayerUno : MaquinaDeEstadoFinitaParaElEscenario
{
    public override void Start()
    {
        //debo Instanciar el primer Player
        EstadisticasBase instanciaDePlayer1;
        try
        {
            var prefabDelPrimerPlayer = ServiceLocatorImplement.Instancie.GetService<IManejadorDePersonaje>().PrimerPlayer();
            //instanciaDePlayer1 = Instantiate(prefabDelPrimerPlayer).transform.Find("General").GetComponent<EstadisticasBase>();
            //instanciaDePlayer1.transform.position = GameObject.Find("PosicionPlayer1").transform.position;
            //instanciaDePlayer1.GetComponent<DatosPersistentesDelPlayer>().playerNumber = 1;
            NombreDelPlayableDirector = "guiaDeCamaraParaPlayer1";
            //ServiceLocator.Instancie.GetService<IGuardarReferenciaDeLosPlayer>().Player1(instanciaDePlayer1.gameObject);
            
        }
        catch (PersonajeElegidoNoExisteException e)
        {
            Debug.Log("No debe instanciar nada");
            instanciaDePlayer1 = new EstadisticasBase();
        }
        base.Start();
        //director.transform.SetParent(instanciaDePlayer1.gameObject.transform);
    }

    public override void Salir()
    {

    }

    public override void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        VerificarCambios();
    }

    public override Type VerficarTransiciones()
    {
        if (deltaTimeLocal >= director.duration)
        {
            return typeof(EstadoDePresentacionDelPlayerDos);
        }
        return GetType();
    }

}
