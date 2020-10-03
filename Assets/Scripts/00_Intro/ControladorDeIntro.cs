using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ControladorDeIntro : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private InputManager input;
    private float deltaTimeLocal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (input.SeprecionoElBoton(InputDefinidosParaElJuego.Start) || input.SeprecionoElBoton(InputDefinidosParaElJuego.Start_p2))
        {
            SceneManager.LoadScene((int)IndicesDeEscenas.PELEA);
        }
    }
}
