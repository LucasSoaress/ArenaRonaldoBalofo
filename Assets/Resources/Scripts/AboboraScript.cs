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

    public static float direcaoDoPersonagem; 


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
        float movimento = Input.GetAxisRaw(CONTROLE_VERTICAL);
       if(movimento < -0.3f || movimento > 0.3f)
       {
           float TranslationY = Input.GetAxisRaw(CONTROLE_VERTICAL) * velocidade * Time.deltaTime;
           personagem1.transform.Translate(0, TranslationY, 0);
       }

       float outroMovimento = Input.GetAxisRaw(CONTROLE_HORIZONTAL);
       if(outroMovimento < -0.3f || outroMovimento > 0.3f)
       {
           float TranslationX = Input.GetAxisRaw(CONTROLE_HORIZONTAL) * velocidade * Time.deltaTime;
           personagem1.transform.Translate(TranslationX, 0, 0);
       }

       Debug.Log(movimento);
    }

   /// <summary>
   /// Método para o personagem atirar
   /// Fire1 = Botão A
   /// </summary>
  private void Shooter()
   {
      if (Input.GetKeyDown(KeyCode.Joystick1Button14))
      {
          direcaoDoPersonagem = Input.GetAxisRaw(CONTROLE_HORIZONTAL);

          if (direcaoDoPersonagem < 0)
          {
              tiroAbobora.velocidadeTiro = tiroAbobora.velocidadeTiro * -1;
          }
          else if(direcaoDoPersonagem > 0)
          {
              tiroAbobora.velocidadeTiro = 3f;
          }

          Vector3 pos = this.transform.position;
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