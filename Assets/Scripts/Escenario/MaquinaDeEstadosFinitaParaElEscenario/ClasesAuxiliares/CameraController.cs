using Cinemachine;
using UnityEngine;

public class CameraController
{
    public void ComenzarSeguirObjetoEnEscena(CinemachineVirtualCamera camara, string aQuienSeguir)
    {
        camara.Follow = GameObject.Find(aQuienSeguir).transform;
        //camara.LookAt = camara.Follow;
    }
}