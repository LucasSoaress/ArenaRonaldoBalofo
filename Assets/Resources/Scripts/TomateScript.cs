using UnityEngine;
using System.Collections;

public class TomateScript : MonoBehaviour {

	public GameObject Tomate;
    public float velocidade;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    //Vida
    public static int HealthTomate;

    // Use this for initialization
    void Start () {

        HealthTomate = 100;

    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Vida();
    }

    void Vida() {

        if (HealthTomate <= 0)
        {
			Destroy(Tomate);
        }
    }

    void Move() {

        float TranslationY = Input.GetAxisRaw("P4_Vertical") * velocidade * Time.deltaTime;
		Tomate.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P4_Horizontal") * velocidade * Time.deltaTime;
		Tomate.transform.Translate(TranslationX, 0, 0);


    }

	void OnTriggerStay2D(Collider2D coll)
	{
		Debug.Log ("Entrou");
		if (coll.gameObject.tag == "Lama")
		{
			velocidade = 1;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		Debug.Log ("Saiu"); 
		velocidade = 3;
	}
}
