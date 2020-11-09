using System;

public class EstadoDePreparacionDePeleaReady : MaquinaDeEstadoFinitaParaElEscenario
{

    public override void Start()
    {
        NombreDelPlayableDirector = "guiaDeCamaraParaReady";
        base.Start();

        //obtener a los dos jugadores e inicializarlos
        ServiceLocator.Instancie.GetService<IObtenerReferenciaDeLosPlayer>().Player1();
    }
    public override void Salir()
    {
        
    }

    public override void Update()
    {
        VerificarCambios();
    }

    public override Type VerficarTransiciones()
    {
        return GetType();
    }
}