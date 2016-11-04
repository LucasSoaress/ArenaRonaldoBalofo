using UnityEngine;
using System.Collections;

public class tiroAbobora : MonoBehaviour 
{

    public static float velocidadeTiro;

	void Start () 
    {
        velocidadeTiro = 3f;
	}
	
	void Update () 
    {
        this.transform.Translate(Vector2.right * velocidadeTiro * Time.deltaTime);
	}

    /// <summary>
    /// Destrui objetos quando não estão visiveis
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
