using UnityEngine;
using System.Collections;

public class Cyborg : EstadisticasBase
{

    public override void Awake()
    {
        base.Awake();
        //
        //delegamos la lectura del archivo a otro coso
        string stringDeEstadisticasGenrales = ManejadorDeArchivos.LeerArchivo(@"debug_EstadisticasPJ_" + typeof(Cyborg).Name+".txt");
        Debug.Log(stringDeEstadisticasGenrales);

        EstadisticasBasePersonajeDebug estadisticasBase = JsonUtility.FromJson<EstadisticasBasePersonajeDebug>(stringDeEstadisticasGenrales);
        Vida += estadisticasBase.vida;
        Fuerza += estadisticasBase.fuerza;
        FuerzaGolpeDebil += estadisticasBase.fuerzaGolpeDebil;
        FuerzaGolpeFuerte += estadisticasBase.fuerzaGolpeFuerte;
        FuerzaEmpujeDragonPunch += estadisticasBase.fuerzaEmpujeDragonPunch;
        FuerzaDragonPunch += estadisticasBase.fuerzaDragonPunch;
        Patada += estadisticasBase.patada;
        Punio += estadisticasBase.patada;
        SpeedJump += estadisticasBase.speedJump;
        Speed += estadisticasBase.speed;
        TiempoRecuperacion += estadisticasBase.tiempoRecuperacion;
        TiempoGolpeado += estadisticasBase.tiempoGolpeado;
        SpeedFireBall += estadisticasBase.speedFireBal;
        FuerzaDeSaltoHaciaAtras += estadisticasBase.fuerzaDeSaltoHaciaAtras;
        FuerzaHaciaArriba += estadisticasBase.fuerzaHaciaArriba;
        SaltaAlDragonPunch = estadisticasBase.saltaAlDragonPunch;
    }

}
