using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMaquinaEstadosFinita : MonoBehaviour
{
    protected Animator componenteDeAnimacion;
    protected InterfazDeMetodosGenericosParaAcciones accionesDelPersonaje;
    [SerializeField]
    protected GameObject oponente;
    protected int playerNumber;
    protected DatosPersistentesDelPlayer player;
    protected InputDefinidosParaElJuego patadaDebil, patadaFuerte, punioDebil, punioFuerte;
    protected float movimientoInyectado = 0;
    protected string baseNombreHorizontal = "Horizontal_Player";
    protected string baseNombreVertical = "Vertical_Player";
    protected MovimientoGenerico movimientoDelObjeto;

    protected InputManager inputManager;
    protected bool terminoLaAnimacion = false;
    public abstract void Salir();
    public virtual void Start()
    {
        inputManager = GameObject.Find("ControladorDeEscenario").GetComponent<InputManager>();
        componenteDeAnimacion = GetComponent<Animator>();
        accionesDelPersonaje = GetComponent<InterfazDeMetodosGenericosParaAcciones>();
        player = GetComponent<DatosPersistentesDelPlayer>();
        playerNumber = player.playerNumber;
        oponente = BuscandoOponente();
        baseNombreHorizontal += playerNumber.ToString();
        baseNombreVertical += playerNumber.ToString();
        movimientoDelObjeto = GetComponent<MovimientoGenerico>();
        if (playerNumber == 2)
        {
            punioDebil = InputDefinidosParaElJuego.PunioDebil_p2;
            punioFuerte = InputDefinidosParaElJuego.PunioFuerte_p2;
            patadaDebil = InputDefinidosParaElJuego.PatadaDebil_p2;
            patadaFuerte = InputDefinidosParaElJuego.PatadaFuerte_p2;
        }
        else if (playerNumber == 1)
        {
            punioDebil = InputDefinidosParaElJuego.PunioDebil;
            punioFuerte = InputDefinidosParaElJuego.PunioFuerte;
            patadaDebil = InputDefinidosParaElJuego.PatadaDebil;
            patadaFuerte = InputDefinidosParaElJuego.PatadaFuerte;
        }
    }

    public abstract void Update();

    public abstract Type VerficarTransiciones();

    public void VerificarCambios()
    {
        Type estadoACambiar = VerficarTransiciones();
        if (estadoACambiar != this.GetType())
        {
            CambiarEstado(estadoACambiar);
        }
    }

    public void CambiarEstado(Type nuevoEstado)
    {
        //agregamos el componente
        gameObject.AddComponent(nuevoEstado);
        //salir del estado actual
        Salir();
        //destuimos el estado viejo
        Destroy(this);
    }

    //Buscamos al oponente y lo retornamos
    //Necesitamos saber que player somos nosotros
    //Buscamos entre todos los tags de "Player"
    //le buscamos su componente de Maquina de estado finita (BaseMaquinaEstadosFinita)
    //Le preguntamos que player es, y si es uno distinto al player de este script lo retornamos
    private GameObject BuscandoOponente()
    {
        //con este componente
        GameObject[] listaDePlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in listaDePlayers)
        {
            if(player.GetComponent<BaseMaquinaEstadosFinita>().playerNumber != playerNumber)
            {
                return player;
            }
        }
        throw new Exception("No encontramos al oponete del player " + playerNumber);
    }


    protected bool ElOponenteEstaAtacando()
    {
        if (oponente.GetComponent<BaseMaquinaEstadosFinita>().GetType() == typeof(EstadoAtacar))
        {
            return true;
        }
        return false;
    }

    protected bool EstaEchandoParaAtras()
    {
        //tenemos que ubicar al opoenente y con relacion a el ver si la palanca esta echando hacia atras o adelante de el.
        Vector2 diff = (gameObject.transform.position - oponente.transform.position);
        if ((diff.x < 0 && inputManager.SeMovioHorizontalmente(playerNumber) < 0) || (diff.x > 0 && inputManager.SeMovioHorizontalmente(playerNumber) > 0))
        {
            return true;
        }
        return false;
    }

    public int CardinalidadDeHaciaAtras()
    {
        Vector2 diff = (gameObject.transform.position - oponente.transform.position);
        if(diff.x < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public float MovimientoInyectado
    {
        set { movimientoInyectado = value; }
        get { return movimientoInyectado; }
    }

    public bool IsGolpeado
    {
        get { return player.FueGolpeado; }
        set { player.FueGolpeado = value; }
    }

    public string Vertical
    {
        get { return baseNombreVertical; }
    }
    public string Horizontal
    {
        get { return baseNombreHorizontal; }
    }

    public Animator ComponenteAnimacion
    {
        get { return componenteDeAnimacion; }
    }

    public InterfazDeMetodosGenericosParaAcciones AccionesDelPersonaje
    {
        get { return accionesDelPersonaje; }
    }

    public DatosPersistentesDelPlayer Player
    {
        get { return player; }
    }

    public InputDefinidosParaElJuego PatadaDebil { get => patadaDebil; }
    public InputDefinidosParaElJuego PatadaFuerte { get => patadaFuerte; }
    public InputDefinidosParaElJuego PunioDebil { get => punioDebil; }
    public InputDefinidosParaElJuego PunioFuerte { get => punioFuerte; }
    public int PlayerNumber { get => playerNumber; }

    public virtual void FinalDePatada()
    {
        accionesDelPersonaje.IsPatadaActivo = false;
        GetComponent<Animator>().SetBool("patada", false);
        terminoLaAnimacion = true;
    }
    public virtual void FinalDePunio()
    {
        accionesDelPersonaje.IsPunioActivo = false;
        GetComponent<Animator>().SetBool("punio", false);
        terminoLaAnimacion = true;
    }

    public virtual void FinalDragonPunch()
    {
        accionesDelPersonaje.IsDragonPunch = false;
        GetComponent<Animator>().SetBool("dragonPunch", false);
        terminoLaAnimacion = true;
    }

    public void FinDeDash()
    {
        GetComponent<Animator>().SetBool("dash", false);
    }
}
