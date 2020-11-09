using UnityEngine;

public class ControladorDeEstadosDeLaPelea : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<EstadoDePresentacionDeEscenario>();
    }
}
