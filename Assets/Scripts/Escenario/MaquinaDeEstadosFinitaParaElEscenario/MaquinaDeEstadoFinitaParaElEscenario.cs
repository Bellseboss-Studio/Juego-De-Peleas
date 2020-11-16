using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public abstract class MaquinaDeEstadoFinitaParaElEscenario : EstadoDeMaquina
{
    protected CinemachineTargetGroup grupo;
    protected CinemachineVirtualCamera camara;
    protected PlayableDirector director;
    protected float deltaTimeLocal;

    protected string NombreDelPlayableDirector { get; set; }

    public override void Start()
    {
        base.Start();
        camara = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        //Buscar el director en el player
        director = GameObject.Find(NombreDelPlayableDirector).GetComponent<PlayableDirector>();
        new CameraController().ComenzarSeguirObjetoEnEscena(camara, NombreDelPlayableDirector);
        new DirectorDeTimeLineController().EjecutandoLaAnimacionDelTimeLineRespectiva(director);
    }
}