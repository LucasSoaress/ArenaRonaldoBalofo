using UnityEngine;
using System.Collections;

public class CenouraScript : MonoBehaviour {

    public GameObject personagem2;
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
            Destroy(personagem2);
        }
    }

    void Move()
    {

        float TranslationY = Input.GetAxisRaw("P2_Vertical") * velocidade * Time.deltaTime;
        personagem2.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P2_Horizontal") * velocidade * Time.deltaTime;
        personagem2.transform.Translate(TranslationX, 0, 0);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lama")
        {

            velocidade = 1;

        }

    }
}
