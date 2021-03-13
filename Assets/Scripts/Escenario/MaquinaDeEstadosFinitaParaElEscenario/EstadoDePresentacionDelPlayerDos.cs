using ServiceLocator;
using System;
using UnityEngine;

public class EstadoDePresentacionDelPlayerDos : MaquinaDeEstadoFinitaParaElEscenario
{
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
            return typeof(EstadoDePreparacionDePeleaReady);
        }
        return GetType();
    }

    public override void Start()
    {
        //debo Instanciar el primer Player
        EstadisticasBase instanciaDePlayer2;
        try
        {
            var prefabDelPrimerPlayer = ServiceLocatorImplement.Instancie.GetService<IManejadorDePersonaje>().SegundoPlayer();
            //instanciaDePlayer2 = Instantiate(prefabDelPrimerPlayer).transform.Find("General").GetComponent<EstadisticasBase>();

            //instanciaDePlayer2.transform.position = GameObject.Find("PosicionPlayer2").transform.position;
            //instanciaDePlayer2.transform.rotation = new Quaternion(0, 180, 0, 0);
            //instanciaDePlayer2.GetComponent<DatosPersistentesDelPlayer>().playerNumber = 2;
            //ServiceLocator.Instancie.GetService<IGuardarReferenciaDeLosPlayer>().Player2(instanciaDePlayer2.gameObject);
        }
        catch(PersonajeElegidoNoExisteException e)
        {
            Debug.Log("No debe instanciar nada");
            instanciaDePlayer2 = new EstadisticasBase();
        }

        NombreDelPlayableDirector = "guiaDeCamaraParaPlayer2";
        base.Start();
        //director.transform.SetParent(instanciaDePlayer2.transform);
    }


}
