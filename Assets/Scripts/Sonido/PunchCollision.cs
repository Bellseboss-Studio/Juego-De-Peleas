using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCollision : MonoBehaviour
{
    public AK.Wwise.Event punchHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            punchHit.Post(gameObject);
        }
    }
}
