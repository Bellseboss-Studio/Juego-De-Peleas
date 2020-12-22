using UnityEngine;

public class Player : IPlayerJuegoDePelea
{
    public int player { get; set; }
    public float x { get; set; }
    public float y { get; set; }
    public GameObject gameObject { get; set; }
    public bool SeSelecciono { get; set; }

    public string ToString()
    {
        return "player " + player + ", x " + x + ", y " + y + ", gameObject " + gameObject.name + " Se selecciono " + SeSelecciono;
    }
}