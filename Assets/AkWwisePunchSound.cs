using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkWwisePunchSound : MonoBehaviour
{
    public AK.Wwise.Event punchSoundEvent;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        punchSoundEvent.Post(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        punchSoundEvent.Post(gameObject);
    }
}
