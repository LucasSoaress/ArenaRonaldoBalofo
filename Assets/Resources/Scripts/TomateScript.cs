using UnityEngine;
using System.Collections;

public class TomateScript : MonoBehaviour {

    public GameObject personagem4;
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
            Destroy(personagem4);
        }
    }

    void Move() {

        float TranslationY = Input.GetAxisRaw("P4_Vertical") * velocidade * Time.deltaTime;
        personagem4.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P4_Horizontal") * velocidade * Time.deltaTime;
        personagem4.transform.Translate(TranslationX, 0, 0);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lama") {

            velocidade = 1;

        }

    }
}
