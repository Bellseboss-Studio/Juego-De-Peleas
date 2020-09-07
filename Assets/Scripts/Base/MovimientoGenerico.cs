﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovimientoGenerico : MonoBehaviour
{
    private bool comenzarContar, logeoDeSalto;
    private Rigidbody2D rb;
    private float min, max, x, y, deltaTimeLocal, alturamax, deltaTimeLocalParaControl, velocidadDash, deltaTimeLocalParaDashHaciaAtras;
    private bool correrHaciaAtras = false;
    private BaseMaquinaEstadosFinita maquina;
    [Range(0f, 2f)]
    [SerializeField]
    private float tiempoDeReseteoDeCola;
    private Queue<string> palancas, dash;
    [SerializeField]
    private int stackMaximo;
    [SerializeField]
    private KeyCode botonPrecionado;
    EstadisticaMovimiento estadisticasMovimiento;
    InputManager im;

    public AK.Wwise.Event Woosh;

    private void Start()
    {
        im = GameObject.Find("ControladorDeEscenario").GetComponent<InputManager>();
        //Todo el codigo aqui
        min = -1f;
        max = 1f;
        rb = GetComponent<Rigidbody2D>();
        deltaTimeLocal = min;
        maquina = GetComponent<BaseMaquinaEstadosFinita>();
        palancas = new Queue<string>();
        velocidadDash = 1;
        //Vamos a buscar configuracion del delay
        string stringDeEstadisticasGenrales = ManejadorDeArchivos.LeerArchivo(@"debug_EstadisticaMovimiento.txt");
        Debug.Log(stringDeEstadisticasGenrales);
        estadisticasMovimiento = JsonUtility.FromJson<EstadisticaMovimiento>(stringDeEstadisticasGenrales);
    }
    private void Update()
    {
        if (correrHaciaAtras)
        {
            //Debug.Log("X " + x + " speed " + maquina.AccionesDelPersonaje.Speed + " Fuerza " + fuerzaDeSaltoHaciaAtras);
            rb.velocity = new Vector2(x * maquina.AccionesDelPersonaje.Speed * GetComponent<BaseMaquinaEstadosFinita>().AccionesDelPersonaje.FuerzaDeSaltoHaciaAtras, y);
            deltaTimeLocalParaDashHaciaAtras += Time.deltaTime;
            if (deltaTimeLocalParaDashHaciaAtras >= GetComponent<BaseMaquinaEstadosFinita>().AccionesDelPersonaje.TiempoDeDashHaciaAtras)
            {
                deltaTimeLocalParaDashHaciaAtras = 0;
                correrHaciaAtras = false;
            }
        }
        else
        {
            if (!comenzarContar)
            {
                if (GetMovimientoDelObjeto() > estadisticasMovimiento.lagHaciaDerecha)
                {
                    x = 1;
                    LogearComandosIngresados();
                }
                if (GetMovimientoDelObjeto() < estadisticasMovimiento.lagHaciaIzquerda)
                {
                    x = -1;
                    LogearComandosIngresados();
                }
                if (GetMovimientoDelObjeto() == 0)
                {
                    x = 0;
                    velocidadDash = 1;
                    GetComponent<BaseMaquinaEstadosFinita>().ComponenteAnimacion.SetBool("correr", false);
                    LogearComandosIngresados();
                }
                if (im.SeMovioVerticalmente(maquina.PlayerNumber) > estadisticasMovimiento.lagHaciaArriba)
                {
                    maquina.ComponenteAnimacion.SetTrigger("saltar");
                    maquina.ComponenteAnimacion.SetBool("tocarPiso", false);
                    maquina.AccionesDelPersonaje.EstaEnElPiso = false;
                    comenzarContar = true;
                    LogearComandosIngresados();
                }
                else if (im.SeMovioVerticalmente(maquina.PlayerNumber) < estadisticasMovimiento.lagHaciaAbajo)
                {
                    LogearComandosIngresados();
                }
                deltaTimeLocalParaControl += Time.deltaTime;
            }

            if (comenzarContar)
            {

                deltaTimeLocal += (Time.deltaTime * 2);
                //ir modificando a una funcion matematica mas suave en su movimiento
                y = Mathf.Cos(deltaTimeLocal) * maquina.AccionesDelPersonaje.SpeedJump;

                if (GetComponent<BaseMaquinaEstadosFinita>().GetType().Equals(typeof(EstadoAtacar)) && !GetComponent<InterfazDeMetodosGenericosParaAcciones>().SaltaAlDragonPunch)
                {
                    y = 0;
                }

                //Como por ejemplo
                //2x^(3)+2
                //y = ((2 * Mathf.Pow(deltaTimeLocal, 3)) + 2) * speedJump;
                if (y > alturamax)
                {
                    alturamax = y;
                }
                else
                {
                    y *= -1;
                }
                if (deltaTimeLocal >= max)
                {
                    ResetObject();
                }
                LogearComandosIngresados();
            }
            else
            {
                y = rb.velocity.y;
            }
            rb.velocity = new Vector2(x * maquina.AccionesDelPersonaje.Speed * velocidadDash, y);
        }
        GetComponent<Animator>().SetFloat("velocidad", Mathf.Abs(rb.velocity.x));
    }

    public string CardinalidadEscritaHorizontal()
    {
        string resultadoDelMovimiento;
        if (GetMovimientoDelObjeto() > estadisticasMovimiento.lagHaciaDerecha)
        {
            if (GetComponent<BaseMaquinaEstadosFinita>().CardinalidadDeHaciaAtras() > 0)
            {
                resultadoDelMovimiento = SecuenciasPermitidas.ATRAS;
            }
            else
            {
                resultadoDelMovimiento = SecuenciasPermitidas.DELANTE;
            }
        }else if (GetMovimientoDelObjeto() < estadisticasMovimiento.lagHaciaIzquerda)
        {
            if (GetComponent<BaseMaquinaEstadosFinita>().CardinalidadDeHaciaAtras() < 0)
            {
                resultadoDelMovimiento = SecuenciasPermitidas.ATRAS;
            }
            else
            {
                resultadoDelMovimiento = SecuenciasPermitidas.DELANTE;   
            }
        }else
        {
            resultadoDelMovimiento = SecuenciasPermitidas.VACIO;
        }
        return resultadoDelMovimiento;
    }

    public string CardinalidadEscritaVertical()
    {
        if (im.SeMovioVerticalmente(maquina.PlayerNumber) > estadisticasMovimiento.lagHaciaArriba)
        {
            return SecuenciasPermitidas.ARRIBA;
        }
        else if (im.SeMovioVerticalmente(maquina.PlayerNumber) < estadisticasMovimiento.lagHaciaAbajo)
        {
            return SecuenciasPermitidas.ABAJO;
        }
        else
        {
            return SecuenciasPermitidas.VACIO;
        }
    }

    public void LogearComandosIngresados(KeyCode control)
    {
        botonPrecionado = control;
        LogearComandosIngresados();
    }
    public void LogearComandosIngresados()
    {
        if (deltaTimeLocalParaControl < tiempoDeReseteoDeCola)
        {
            string loQueVamosLogear = string.Empty;
            if (botonPrecionado != KeyCode.None)
            {
                if (im.BotonPrecionado(maquina.PatadaDebil) == botonPrecionado)
                {
                    loQueVamosLogear = SecuenciasPermitidas.PATADADEBIL;
                }
                else if (im.BotonPrecionado(maquina.PatadaFuerte) == botonPrecionado)
                {
                    loQueVamosLogear = SecuenciasPermitidas.PATADAFUERTE;
                }
                else if (im.BotonPrecionado(maquina.PunioDebil) == botonPrecionado)
                {
                    loQueVamosLogear = SecuenciasPermitidas.PUNIODEBIL;
                }
                else if (im.BotonPrecionado(maquina.PunioFuerte) == botonPrecionado)
                {
                    loQueVamosLogear = SecuenciasPermitidas.PUNIOFUERTE;
                }
            }else
            {
                loQueVamosLogear = CardinalidadEscritaHorizontal() + CardinalidadEscritaVertical();
            }
            //comprobar si el que vamos a ingresar ya esta en la ultima posicion
            if (palancas.Count >= 1)
            {
                if (!palancas.Last().Equals(loQueVamosLogear))
                {
                    palancas.Enqueue(loQueVamosLogear);
                }
            }
            else
            {
                palancas.Enqueue(loQueVamosLogear);
            }
            //Debug.LogError(loQueVamosLogear);
            //seteamos el boton para que regrese a su estado original! sellado magico!!!!!
            botonPrecionado = KeyCode.None;
            if (palancas.Count > stackMaximo)
            {
                palancas.Dequeue();
            }
            //analizaremos lo que esta guardado, contra lo que tenemos almacenado en el diccionario de secuencias

            DetectorDeConvinaciones();
        }
        else
        {
            //Debug.LogWarning(">>>>>"+ deltaTimeLocalParaControl);
            deltaTimeLocalParaControl = 0;
            palancas = new Queue<string>();
        }

    }

    private void DetectorDeConvinaciones()
    {
        foreach (KeyValuePair<string, Queue<string>> result in GetComponent<InterfazDeMetodosGenericosParaAcciones>().ListadoDeSecuencias)
        {
            int i = 0;//.ToList()[i]
            foreach (string stack in palancas)
            {
                if (stack.Equals(result.Value.ToList()[i]))
                {
                    i++;
                    //continue;
                }else
                {
                    continue;
                }
                if (result.Value.ToList().Count == i)
                {
                    switch (result.Key)
                    {
                        case SecuenciasPermitidas.FIREBALL:
                            //instaciamos el objeto
                            //llenamos los datos que le falten (padre)
                            GetComponent<InterfazDeMetodosGenericosParaAcciones>().IsFireBall = true;
                            GameObject fireBall = GetComponent<InterfazDeMetodosGenericosParaAcciones>().FireBallPrefab;
                            Instantiate(fireBall, gameObject.transform.position, fireBall.transform.rotation).GetComponent<ReferenciaAlPadre>().padre = gameObject;
                            break;
                        case SecuenciasPermitidas.CORRER:
                            GetComponent<BaseMaquinaEstadosFinita>().ComponenteAnimacion.SetBool("correr", true);
                            Debug.LogWarning("Corre perra... corrre!");
                            velocidadDash = 4;
                            //posiblemente activemos una animación
                            break;

                        case SecuenciasPermitidas.SALTARHACIAATRAS:
                            Debug.LogWarning("Dash hacia atras!");
                            correrHaciaAtras = true;
                            GetComponent<BaseMaquinaEstadosFinita>().ComponenteAnimacion.SetBool("dash",true);
                            break;
                        case SecuenciasPermitidas.DRAGONPUNCH:
                            //accedemos a las estadisticas base, y le colocamos el dragon punch en true
                            GetComponent<InterfazDeMetodosGenericosParaAcciones>().IsDragonPunch = true;
                            break;
                    }
                    Debug.Log(result.Key);
                    //reseteamos la cola de comnandos
                    palancas = new Queue<string>();
                }
            }
        }
    }

    protected float GetMovimientoDelObjeto()
    {
        if (maquina.MovimientoInyectado != 0)
        {
            return maquina.MovimientoInyectado;
        }
        else
        {
            return im.SeMovioHorizontalmente(maquina.PlayerNumber);
        }
    }

    public void ResetObject()
    {
        comenzarContar = false;
        deltaTimeLocal = min;
        y = 0;
        alturamax = -1;
        GetComponent<Animator>().SetBool("tocarPiso", true);
    }
    public bool ComenzarContar { set => comenzarContar = value; }
    public float X { set => x = value; }

    public void AplicarFuerzaPersonaje(float fuerzaEnX)
    {
        rb.AddForce(new Vector2(fuerzaEnX, 0));
    }

    public void PlayWooshSound()
    {
        Woosh.Post(gameObject);
    }
}
