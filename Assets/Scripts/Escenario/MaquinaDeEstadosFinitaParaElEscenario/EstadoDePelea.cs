using Cinemachine;
using System;
using UnityEngine;

public class EstadoDePelea : MaquinaDeEstadoFinitaParaElEscenario
{
    public override void Start()
    {
        camara = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        new CameraController().ComenzarSeguirObjetoEnEscena(camara, "TargetGroup1");
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