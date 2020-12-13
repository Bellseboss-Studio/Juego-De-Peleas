using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDelJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectsOfType<ControladorDelJuego>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    
}
