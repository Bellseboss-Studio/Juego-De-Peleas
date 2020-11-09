using System;
using UnityEngine;

public abstract class EstadoDeMaquina : MonoBehaviour {
    public abstract void Salir();
    public virtual void Start()
    {
        
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

}
