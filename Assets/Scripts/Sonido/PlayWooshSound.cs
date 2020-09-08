using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWooshSound : MonoBehaviour
{
    public AK.Wwise.Event woosh;
    public AK.Wwise.Event punch;

    public void PlayWoosh()
    {
        woosh.Post(gameObject);
    }

    public void PlayPunch()
    {
        punch.Post(gameObject);
    }    
}
