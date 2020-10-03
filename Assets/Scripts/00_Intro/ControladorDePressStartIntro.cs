using UnityEngine;

public class ControladorDePressStartIntro : MonoBehaviour
{
    private float deltaTimeLocal;
    [SerializeField] private float tiempoDeParoadeo;
    private bool prender;
    private void Update()
    {
        deltaTimeLocal += Time.deltaTime;
        if(deltaTimeLocal > (prender?tiempoDeParoadeo / 2 : tiempoDeParoadeo))
        {
            deltaTimeLocal = 0;
            GetComponent<SpriteRenderer>().enabled = prender;
            prender = !prender;

        }
    }
}