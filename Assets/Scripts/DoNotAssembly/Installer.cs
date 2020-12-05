using ServiceLocator;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private List<CharacterBase> personajesElegibles;
    private void Awake()
    {
        var obtenerData = new GuardadoDeDatosPorPlayerPref();
        ServiceLocatorImplement.Instancie.RegisterService<IObtenerData>(obtenerData);
        ServiceLocatorImplement.Instancie.RegisterService<IGuardarData>(obtenerData);

        var manejadorDePersonajes = new ManejadorDePersonajes();
        manejadorDePersonajes.Installer(personajesElegibles);
        ServiceLocatorImplement.Instancie.RegisterService<IManejadorDePersonaje>(manejadorDePersonajes);
        ServiceLocatorImplement.Instancie.RegisterService<IObtenerReferenciaDeLosPlayer>(manejadorDePersonajes);
        ServiceLocatorImplement.Instancie.RegisterService<IGuardarReferenciaDeLosPlayer>(manejadorDePersonajes);

        var searchingFile = new SearchFile();
        ServiceLocatorImplement.Instancie.RegisterService<ISearchFile>(searchingFile);

        var jsonItulity = new FacadeJsonUtility();
        ServiceLocatorImplement.Instancie.RegisterService<IFacadeJsonUtility>(jsonItulity);
    }
}
