﻿using System;
using UnityEngine;

public class EstadoDePresentacionDeEscenario : MaquinaDeEstadoFinitaParaElEscenario
{
    
    public override void Start()
    {
        NombreDelPlayableDirector = "guiaDeCamara1";
        base.Start();
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
            return typeof(EstadoDePresentacionDelPlayerUno);
        }
        return GetType();
    }

    public override void Salir()
    {
        //por ahora no hace nada
    }

}
