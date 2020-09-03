using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaParaInputManager : MonoBehaviour
{
    public bool IsJoistick;
    private string control;
    // Update is called once per frame
    void Update()
    {
        if (IsJoistick)
        {
            control = "joystick button 0";
        }
        else
        {
            control = "z";
        }
        if (Input.GetKey(control))
        {
            Debug.LogError("PatadaFuerte");
        }
    }
}
