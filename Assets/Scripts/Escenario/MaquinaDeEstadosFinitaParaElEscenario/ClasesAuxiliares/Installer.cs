using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private List<BasePlayer> personajesElegibles;
    private void Awake()
    {
        var obtenerData = new GuardadoDeDatosPorPlayerPref();
        ServiceLocator.Instancie.RegisterService<IObtenerData>(obtenerData);
        ServiceLocator.Instancie.RegisterService<IGuardarData>(obtenerData);

        var manejadorDePersonajes = new ManejadorDePersonajes();
        manejadorDePersonajes.Installer(personajesElegibles);
        ServiceLocator.Instancie.RegisterService<IManejadorDePersonaje>(manejadorDePersonajes);
        ServiceLocator.Instancie.RegisterService<IObtenerReferenciaDeLosPlayer>(manejadorDePersonajes);
        ServiceLocator.Instancie.RegisterService<IGuardarReferenciaDeLosPlayer>(manejadorDePersonajes);
    }
}
