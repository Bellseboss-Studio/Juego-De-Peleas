using UnityEngine;
using System.Collections;
using System;
using Cinemachine;

public class EstadoEstar : BaseMaquinaEstadosFinita
{
    public override void Start()
    {
        base.Start();
    }
    public override void Salir()
    {
        try
        {
            //consulto un componente de tipo atacar y le coloco la variable de lo que se precion para entrar al estado sea el caso de que ataque
            KeyCode botonPrecionado = DeterminacionDeQueBotonSePreciono();
            if (botonPrecionado != KeyCode.None)
            {
                GetComponent<EstadoAtacar>().botonPrecionado = botonPrecionado;
            }
        }
        catch(BotonesException e)
        {
            //no pasa nada
        }catch(Exception e)
        {
            //nos liamos
            Debug.LogError(e.Message);
        }

    }

    public override void Update()
    {
        //Siempre hay que verificar los cambios
        VerificarCambios();
    }

    public override Type VerficarTransiciones()
    {
        if (inputManager.SeprecionoElBoton(patadaDebil) || inputManager.SeprecionoElBoton(patadaFuerte) 
            || inputManager.SeprecionoElBoton(punioDebil) || inputManager.SeprecionoElBoton(punioFuerte))
        {
            MandarleAlLogLoQueSePreciono(DeterminacionDeQueBotonSePreciono());
            return typeof(EstadoAtacar);
        }
        if(ElOponenteEstaAtacando() && EstaEchandoParaAtras())
        {
            return typeof(EstadoDefender);
        }
        if (player.FueGolpeado)
        {
            return typeof(EstadoGolpeado);
        }
        return GetType();
    }

    private void MandarleAlLogLoQueSePreciono(KeyCode k)
    {
        movimientoDelObjeto.LogearComandosIngresados(k);
    }

    private KeyCode DeterminacionDeQueBotonSePreciono()
    {
        KeyCode LoQueSePreciono;
        if (inputManager.SeprecionoElBoton(PatadaDebil))
        {
            LoQueSePreciono = inputManager.BotonPrecionado(PatadaDebil);
        }
        else if (inputManager.SeprecionoElBoton(PatadaFuerte))
        {
            LoQueSePreciono = inputManager.BotonPrecionado(PatadaFuerte);
        }
        else if (inputManager.SeprecionoElBoton(PunioDebil))
        {
            LoQueSePreciono = inputManager.BotonPrecionado(PunioDebil);
        }
        else if (inputManager.SeprecionoElBoton(PunioFuerte))
        {
            LoQueSePreciono = inputManager.BotonPrecionado(PunioFuerte);
        }
        else
        {
            throw new BotonesException("No se preciono ningun boton");
        }
        return LoQueSePreciono;
    }

}
