using ServiceLocator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Installer : MonoBehaviour
{
    [SerializeField] private List<CharacterView> personajesElegiblesGO;
    public void Start()
    {

        var searchingFile = new SearchFile();
        ServiceLocatorImplement.Instancie.RegisterService<ISearchFile>(searchingFile);

        var factory = new FactoryStats();
        ServiceLocatorImplement.Instancie.RegisterService<IFactoryStats>(factory);

        List<CharacterBase> personajesElegibles = new List<CharacterBase>();
        foreach (CharacterView go in personajesElegiblesGO)
        {
            go.Start();
            personajesElegibles.Add(go.CharacterBase);
        }

        var manejadorDePersonajes = new ManejadorDePersonajes();
        manejadorDePersonajes.Installer(personajesElegibles);
        //ServiceLocatorImplement.Instancie.RegisterService<IGuardarReferenciaDeLosPlayer>(manejadorDePersonajes);
        //ServiceLocatorImplement.Instancie.RegisterService<IObtenerReferenciaDeLosPlayer>(manejadorDePersonajes);

        /*
        var obtenerData = new GuardadoDeDatosPorPlayerPref();
        ServiceLocatorImplement.Instancie.RegisterService<IObtenerData>(obtenerData);
        ServiceLocatorImplement.Instancie.RegisterService<IGuardarData>(obtenerData);


        ServiceLocatorImplement.Instancie.RegisterService<IManejadorDePersonaje>(manejadorDePersonajes);
        
        


        var jsonItulity = new FacadeJsonUtility();
        ServiceLocatorImplement.Instancie.RegisterService<IFacadeJsonUtility>(jsonItulity);*/
    }
}
