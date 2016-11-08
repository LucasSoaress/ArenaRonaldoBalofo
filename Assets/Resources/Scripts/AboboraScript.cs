using UnityEngine;
using System.Collections;

public class AboboraScript : MonoBehaviour
{
    private int numeroDeBalas;
    public GameObject tiro;
    public float velocidade;
<<<<<<< HEAD
    public float MaxX, MinX, MaxY, MinY;
    public static int HealthAbobora;


=======
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;
    public static int HealthAbobora;

>>>>>>> origin/master
    /// <summary>
    /// Inciando o código para o personagem ter 5 balas e 100 de vida
    /// </summary>
    void Start()
    {
        HealthAbobora = 100;
        numeroDeBalas = 5;
    }

    /// <summary>
    /// Chamando todos os métodos criados
    /// </summary>
    void Update()
    {
        Move();
        Vida();
        Atirar();
    }

    /// <summary>
    /// Realiza ação de verificar se a vida do personagem acabou
    /// </summary>
    private void Vida()
    {
        if (HealthAbobora <= 0)
        {
			Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Realiza movimentação do personagem
    /// </summary>
    private void Move()
    {
<<<<<<< HEAD
        float MoveVertical = Input.GetAxisRaw("P1_Vertical");
        float MoveHorizontal = Input.GetAxisRaw("P1_Horizontal");

        if (MoveVertical <= -0.3f || MoveVertical >= 0.3f) {

            float TranslationY = Input.GetAxisRaw("P1_Vertical") * velocidade * Time.deltaTime;
            this.transform.Translate(0, TranslationY, 0);
        }

        if (MoveHorizontal <= -0.3f || MoveHorizontal >= 0.3f) {

            float TranslationX = Input.GetAxisRaw("P1_Horizontal") * velocidade * Time.deltaTime;
            this.transform.Translate(TranslationX, 0, 0);
        }
=======
        float TranslationY = Input.GetAxisRaw("P1_Vertical") * velocidade * Time.deltaTime;
		this.transform.Translate(0, TranslationY, 0);

        float TranslationX = Input.GetAxisRaw("P1_Horizontal") * velocidade * Time.deltaTime;
		this.transform.Translate(TranslationX, 0, 0);
>>>>>>> origin/master
    }

    /// <summary>
    /// Realização ação de tiro
    /// </summary>
    private void Atirar()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && numeroDeBalas >= 0 && numeroDeBalas <= 5) // TROCAR PARA INPUT DE CONTROLE
        {
            Instantiate(tiro, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            numeroDeBalas -= 1;
        }
    }

    void OnCollisionEnter(Collision2D other) {

        if (other.gameObject.tag == "tomateMunicao" || other.gameObject.tag == "beringelaMunicao" || other.gameObject.tag == "cenouraMunicao") {

            Destroy(other.gameObject);
            HealthAbobora -= 20;
=======
        if (Input.GetKeyDown(KeyCode.Space) && numeroDeBalas >= 0 && numeroDeBalas <= 5) // TROCAR PARA INPUT DE CONTROLE
        {
            Instantiate(tiro, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            numeroDeBalas -= 1;
>>>>>>> origin/master
        }
    }

    /// <summary>
    /// Método para entrada em uma colisão via TRIGGER!!!!!
    /// PRECISA TER ON TRIGGER LIGADO NO COLLIDER
    /// </summary>
    /// <param name="coll">Objeto que colidiu</param>
<<<<<<< HEAD
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Lama")
=======
	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Lama")
>>>>>>> origin/master
		{
			velocidade = 1;
		}

<<<<<<< HEAD
		if (other.gameObject.tag == "Abobora_Canto")
		{
            if (Input.GetKeyUp(KeyCode.Joystick1Button2))
=======
		if (coll.gameObject.tag == "Abobora_Canto")
		{
            if (Input.GetKeyUp(KeyCode.R))
>>>>>>> origin/master
            {
                numeroDeBalas = 5;
            }
		}
	}

    /// <summary>
    /// Método para saida de uma colisão via TRIGGER!!!!!
    /// PRECISA TER ON TRIGGER LIGADO NO COLLIDER
    /// </summary>
<<<<<<< HEAD
    /// <param name="other">Objeto que saiu da colisão</param>
	void OnTriggerExit2D(Collider2D other)
=======
    /// <param name="coll">Objeto que saiu da colisão</param>
	void OnTriggerExit2D(Collider2D coll)
>>>>>>> origin/master
	{
		velocidade = 3;
	}
}