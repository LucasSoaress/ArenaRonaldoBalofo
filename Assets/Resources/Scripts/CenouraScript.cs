using UnityEngine;
using System.Collections;

public class CenouraScript : MonoBehaviour {

	public GameObject Cenoura;
    public float velocidade;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    //vida
    public static int HealthCenoura;


    // Use this for initialization
    void Start () {

        HealthCenoura = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Vida();
    }

    void Vida()
    {

        if (HealthCenoura <= 0)
        {
			Destroy(Cenoura);
        }
    }

    void Move()
    {

        float TranslationY = Input.GetAxisRaw("P2_Vertical") * velocidade * Time.deltaTime;
		Cenoura.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P2_Horizontal") * velocidade * Time.deltaTime;
		Cenoura.transform.Translate(TranslationX, 0, 0);


    }

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Lama")
		{
			velocidade = 1;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		velocidade = 3;
	}
}
