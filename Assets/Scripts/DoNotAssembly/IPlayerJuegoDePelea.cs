using UnityEngine;

public interface IPlayerJuegoDePelea
{
    int player { get; set; }
    float x { get; set; }
    float y { get; set; }
    GameObject gameObject { get; set; }
    bool SeSelecciono { get; set; }
    string ToString();
}