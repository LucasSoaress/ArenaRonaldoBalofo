using UnityEngine;
using System.Collections;

public class tiroAbobora : MonoBehaviour 
{
    float SentidoDoTiroV = Input.GetAxisRaw("P1_Vertical");
    float SentidoDoTiroH = Input.GetAxisRaw("P1_Horizontal");
    public static float velocidadeTiro;

	void Start () 
    {
        
        velocidadeTiro = 5f;
	}

	void Update () 
    {

        if (SentidoDoTiroH >= 0.3f) {
            this.transform.Translate(Vector2.right * velocidadeTiro * Time.deltaTime);
        }
        if (SentidoDoTiroH <= -0.3f) {
            this.transform.Translate(-Vector2.right * velocidadeTiro * Time.deltaTime);
        }
        if (SentidoDoTiroV >= 0.3f)
        {
            this.transform.Translate(Vector2.up * velocidadeTiro * Time.deltaTime);
        }
        if (SentidoDoTiroV <= -0.3f)
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
