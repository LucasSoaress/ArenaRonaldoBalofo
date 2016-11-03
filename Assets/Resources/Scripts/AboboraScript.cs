using UnityEngine;
using System.Collections;

public class AboboraScript : MonoBehaviour
{

    public GameObject personagem1;
    public float velocidade;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    //Vida
    public static int HealthAbobora;


    // Use this for initialization
    void Start() {

        HealthAbobora = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Vida();
    }

    void Vida()
    {

        if (HealthAbobora <= 0)
        {
            Destroy(personagem1);
        }
    }

    void Move()
    {

        float TranslationY = Input.GetAxisRaw("P1_Vertical") * velocidade * Time.deltaTime;
        personagem1.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P1_Horizontal") * velocidade * Time.deltaTime;
        personagem1.transform.Translate(TranslationX, 0, 0);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lama")
        {

            velocidade = 1;

        }

    }

}