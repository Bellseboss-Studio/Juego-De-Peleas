using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ModuloSonidosDelJuego
{
    public abstract class SonidoParaSonar : MonoBehaviour
    {
        [SerializeField] private EnumSonidosDelJuego id;
        [SerializeField] private AK.Wwise.Event evento;

        public EnumSonidosDelJuego Id => id;
        public AK.Wwise.Event Evento => evento;
    }
}
