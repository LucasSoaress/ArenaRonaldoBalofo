using UnityEngine;
using System.Collections;

public class CenouraScript : MonoBehaviour
{
    private int numeroDeBalas;
    public GameObject tiro;
    public float velocidade;
    public static int HealthCenoura;
    private bool PodeAtirar;

    public UnityEngine.UI.Text TextVida;
    /// <summary>
    /// Inciando o código para o personagem ter 5 balas e 100 de vida
    /// </summary>
    void Start()
    {
        HealthCenoura = 100;
        numeroDeBalas = 5;
        PodeAtirar = true;
    }

    /// <summary>
    /// Chamando todos os métodos criados
    /// </summary>
    void Update()
    {
        Move();
        Vida();
        Atirar();
        TextVida.text = HealthCenoura.ToString();
    }

    /// <summary>
    /// Realiza ação de verificar se a vida do personagem acabou
    /// </summary>
    private void Vida()
    {
        if (HealthCenoura <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Realiza movimentação do personagem
    /// </summary>
    private void Move()
    {
        float MoveVertical = Input.GetAxisRaw("P2_Vertical");
        float MoveHorizontal = Input.GetAxisRaw("P2_Horizontal");


        if (MoveVertical <= -0.4f || MoveVertical >= 0.4f)
        {

            float TranslationY = Input.GetAxisRaw("P2_Vertical") * velocidade * Time.deltaTime;
            this.transform.Translate(0, TranslationY, 0);
        }

        if (MoveHorizontal <= -0.4f || MoveHorizontal >= 0.4f)
        {

            float TranslationX = Input.GetAxisRaw("P2_Horizontal") * velocidade * Time.deltaTime;
            this.transform.Translate(TranslationX, 0, 0);
        }

        float distanceZ = (transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, distanceZ)).x;

        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0, distanceZ)).x;

        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.06f, distanceZ)).y;

        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.775f, distanceZ)).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
    }

    /// <summary>
    /// Realização ação de tiro
    /// </summary>
    private void Atirar()
    {
        float MoveVertical = Input.GetAxisRaw("P2_Vertical");
        float MoveHorizontal = Input.GetAxisRaw("P2_Horizontal");

        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && (MoveHorizontal <= -0.4f || MoveHorizontal >= 0.4f) && (MoveVertical <= -0.4f || MoveVertical >= 0.4f) && PodeAtirar == true && numeroDeBalas >= 0 && numeroDeBalas <= 5)
        {

            Instantiate(tiro, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            numeroDeBalas -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "tomateMunicao" || other.gameObject.tag == "beringelaMunicao" || other.gameObject.tag == "aboboraMunicao")
        {

            Destroy(other.gameObject);
            HealthCenoura -= 20;

        }
    }

    /// <summary>
    /// Método para entrada em uma colisão via TRIGGER!!!!!
    /// PRECISA TER ON TRIGGER LIGADO NO COLLIDER
    /// </summary>
    /// <param name="other">Objeto que colidiu</param>
	void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lama")
        {
            velocidade = 1;
        }

        if (other.gameObject.tag == "Cenoura_Canto")
        {

            PodeAtirar = false;

            if (Input.GetKeyUp(KeyCode.Joystick2Button2))

            {
                numeroDeBalas = 5;
            }
        }
    }

    /// <summary>
    /// Método para saida de uma colisão via TRIGGER!!!!!
    /// PRECISA TER ON TRIGGER LIGADO NO COLLIDER
    /// </summary>
    /// <param name="other">Objeto que saiu da colisão</param>
	void OnTriggerExit2D(Collider2D other)
    {
        velocidade = 3;
        PodeAtirar = true;
    }
}