using UnityEngine;
using System.Collections;

/// <summary>
/// Classe para controle do personagem Abobora
/// </summary>
public class AboboraScript : MonoBehaviour
{
    //Movimentação
    public GameObject personagem1;
    public float velocidade;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    public GameObject bala;

    private const string CONTROLE_VERTICAL = "P1_Vertical";
    private const string CONTROLE_HORIZONTAL = "P1_Horizontal";

    //Vida
    public static int HealthAbobora;


    // Use this for initialization
    void Start() 
    {
        HealthAbobora = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Vida();
        Shooter();

        float direcao = Input.GetAxisRaw(CONTROLE_HORIZONTAL);
        Debug.Log(direcao);
    }

    /// <summary>
    /// Método utilizado para verificar vida do personagem
    /// </summary>
  private void Vida()
    {
        if (HealthAbobora <= 0)
        {
            Destroy(personagem1);
        }
    }

    /// <summary>
    /// Método utilizado para movimentação do personagem
    /// </summary>
   private void Move()
    {
        float TranslationY = Input.GetAxisRaw(CONTROLE_VERTICAL) * velocidade * Time.deltaTime;
        personagem1.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw(CONTROLE_HORIZONTAL) * velocidade * Time.deltaTime;
        personagem1.transform.Translate(TranslationX, 0, 0);
    }

   /// <summary>
   /// Método para o personagem atirar
   /// Fire1 = Botão A
   /// </summary>
  private void Shooter()
   {
      if (Input.GetButtonDown("Fire1"))
      {
          Vector3 pos = localBala.transform.position;
          Instantiate(bala, new Vector2(pos.x, pos.y), Quaternion.identity);
      }
   }

    /// <summary>
    /// Método para entrar em colisão por Trigger
    /// </summary>
    /// <param name="other">Recebe o objeto que irá colidir</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lama")
        {
            velocidade = 1;
        }
    }

    /// <summary>
    /// Método para sair da colisão por Trigger
    /// </summary>
    /// <param name="other">Recebe objeto que irá sair da colisão</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lama")
        {
            velocidade = 3;
        }
    }
}