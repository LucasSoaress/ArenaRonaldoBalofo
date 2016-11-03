using UnityEngine;
using System.Collections;

public class PimentaScript : MonoBehaviour {

    public GameObject personagem3;
    public float velocidade;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    //Vida
    public static int HealthPimenta;

    // Use this for initialization
    void Start () {

        HealthPimenta = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Vida();
    }

    void Vida()
    {

        if (HealthPimenta <= 0)
        {
            Destroy(personagem3);
        }
    }

    void Move()
    {

        float TranslationY = Input.GetAxisRaw("P3_Vertical") * velocidade * Time.deltaTime;
        personagem3.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P3_Horizontal") * velocidade * Time.deltaTime;
        personagem3.transform.Translate(TranslationX, 0, 0);


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lama")
        {

            velocidade = 1;

        }

    }
}
