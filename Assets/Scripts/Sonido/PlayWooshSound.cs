using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWooshSound : MonoBehaviour
{
    public AK.Wwise.Event woosh;
    

    public void PlayWoosh()
    {
        woosh.Post(gameObject);
    }

   
}
