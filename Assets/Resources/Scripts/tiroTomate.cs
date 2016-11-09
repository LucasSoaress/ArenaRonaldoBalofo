using UnityEngine;
using System.Collections;

public class tiroTomate : MonoBehaviour
{

    public static float velocidadeTiro;
    float SentidoDoTiroV = Input.GetAxisRaw("P3_Vertical");
    float SentidoDoTiroH = Input.GetAxisRaw("P3_Horizontal");

    void Start()
    {

        velocidadeTiro = 5f;
    }

    void Update()
    {

        if (SentidoDoTiroH >= 0.4f)
        {
            this.transform.Translate(Vector2.right * velocidadeTiro * Time.deltaTime);
        }
        if (SentidoDoTiroH <= -0.4f)
        {
            this.transform.Translate(-Vector2.right * velocidadeTiro * Time.deltaTime);
        }
        if (SentidoDoTiroV >= 0.4f)
        {
            this.transform.Translate(Vector2.up * velocidadeTiro * Time.deltaTime);
        }
        if (SentidoDoTiroV <= -0.4f)
        {
            this.transform.Translate(-Vector2.up * velocidadeTiro * Time.deltaTime);
        }

    }

    /// <summary>
    /// Destroi objetos quando não estão visiveis
    /// </summary>
    void OnBecameInvisible()
    {

        Destroy(this.gameObject);
    }

}
