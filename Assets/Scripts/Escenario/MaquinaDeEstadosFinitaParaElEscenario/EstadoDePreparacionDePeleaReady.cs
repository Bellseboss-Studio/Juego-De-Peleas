using System;
using UnityEngine;

public class EstadoDePreparacionDePeleaReady : MaquinaDeEstadoFinitaParaElEscenario
{

    public override void Start()
    {
        NombreDelPlayableDirector = "guiaDeCamaraParaReady";
        base.Start();

        //obtener a los dos jugadores e inicializarlos
        ServiceLocator.Instancie.GetService<IObtenerReferenciaDeLosPlayer>().Player1().GetComponent<ControladorDeLaOrientacionDelPJ>().Init();
        ServiceLocator.Instancie.GetService<IObtenerReferenciaDeLosPlayer>().Player2().GetComponent<ControladorDeLaOrientacionDelPJ>().Init();


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
        if(deltaTimeLocal >= director.duration)
        {
            return typeof(EstadoDePelea);
        }
        return GetType();
    }
}
