using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoParaSonar : MonoBehaviour
{
    [SerializeField]private EnumSonidosParaSonar id;
    [SerializeField] private AK.Wwise.Event evento;

    public EnumSonidosParaSonar Id => id;
    public AK.Wwise.Event Evento => evento;
}
