using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkWwisePunchSound : MonoBehaviour
{
    public AK.Wwise.Event punchSoundEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        punchSoundEvent.Post(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        punchSoundEvent.Post(gameObject);
    }
}
