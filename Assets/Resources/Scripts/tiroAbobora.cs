using UnityEngine;
using System.Collections;

public class tiroAbobora : MonoBehaviour 
{
<<<<<<< HEAD
    float SentidoDoTiroV = Input.GetAxisRaw("P1_Vertical");
    float SentidoDoTiroH = Input.GetAxisRaw("P1_Horizontal");
=======

>>>>>>> origin/master
    public static float velocidadeTiro;

	void Start () 
    {
<<<<<<< HEAD
        
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
=======
        velocidadeTiro = 3f;
	}
	
	void Update () 
    {
        this.transform.Translate(Vector2.right * velocidadeTiro * Time.deltaTime);
	}

    /// <summary>
    /// Destrui objetos quando não estão visiveis
>>>>>>> origin/master
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
