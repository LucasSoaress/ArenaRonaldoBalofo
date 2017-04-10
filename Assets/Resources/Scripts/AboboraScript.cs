using UnityEngine;
using System.Collections;

public class AboboraScript : MonoBehaviour
{
    private int numeroDeBalas;
    public GameObject tiro;
    public float velocidade;
    public static int HealthAbobora;
    private bool PodeAtirar, Lesado, Acelerado;

    public static float Tempinho;

    public UnityEngine.UI.Text TextTempinho;
    public UnityEngine.UI.Text TextVida;


    /* ----------------------------------------------
            AAAEEEEEEEEEEEE BIRRRRRRLLLLLL                         
     ----------------------------------------------- */

    public static int icone;


    /// <summary>
    /// Inciando o código para o personagem ter 5 balas e 100 de vida
    /// </summary>
    void Start()
    {
        PodeAtirar = true;
        Lesado = false;
        Acelerado = true;
        HealthAbobora = 100;
        numeroDeBalas = 5;
        Tempinho = 180f;
        icone = 0;
    }

    /// <summary>
    /// Chamando todos os métodos criados
    /// </summary>
    void Update()
    {
        Move();
        Vida();
        Atirar();
        Woodinho();
        
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

        TextVida.text = HealthAbobora.ToString();
    }

    /// <summary>
    /// Realiza movimentação do personagem
    /// </summary>
    private void Move()
    {
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
        float MoveVertical = Input.GetAxisRaw("P1_Vertical");
        float MoveHorizontal = Input.GetAxisRaw("P1_Horizontal");

        var angle = Mathf.Atan2(MoveHorizontal, MoveVertical) * Mathf.Rad2Deg;
        Vector3 rotationVector = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.Euler(rotationVector);

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && (MoveHorizontal <= -0.4f || MoveHorizontal >= 0.4f) && (MoveVertical <= -0.4f || MoveVertical >= 0.4f) && PodeAtirar == true && numeroDeBalas > 0 && numeroDeBalas <= 5)
        {

            Instantiate(tiro, transform.position, Quaternion.Euler(rotationVector));
            numeroDeBalas -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "tomateMunicao" || other.gameObject.tag == "beringelaMunicao" || other.gameObject.tag == "cenouraMunicao") {

            Destroy(other.gameObject);
            HealthAbobora -= 20;
        
        }
    }


    void Woodinho() {

        Tempinho -= Time.deltaTime;
        int min = Mathf.FloorToInt((Tempinho / 60) % 60);
        int sec = Mathf.FloorToInt(Tempinho % 60);


        if (Tempinho < 60)
        {
            TextTempinho.text = "0" + " : " + Mathf.FloorToInt(Tempinho).ToString();
        }

        else
        {
            TextTempinho.text = min.ToString() + " : " + sec.ToString();
        }
        
        if (sec < 10)
        {
            TextTempinho.text = min.ToString() + " : " + "0" + sec.ToString();
        }

        else
        {
            TextTempinho.text = min.ToString() + " : " + sec.ToString();
        }

        if (Tempinho <= 0)
        {
            Application.Quit();
        }

    }

    /// <summary>
    /// Método para entrada em uma colisão via TRIGGER!!!!!
    /// PRECISA TER ON TRIGGER LIGADO NO COLLIDER
    /// </summary>
    /// <param name="other">Objeto que colidiu</param>
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Lama" && Acelerado == true && Lesado == false)
		{
			velocidade = velocidade/2;
            Lesado = true;
            Acelerado = false;
		}

		if (other.gameObject.tag == "Abobora_Canto")
		{

            PodeAtirar = false;

            if (Input.GetKeyUp(KeyCode.Joystick1Button2) && numeroDeBalas <= 3)

            {
                numeroDeBalas++;
                icone++;
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
        if (Lesado == true) 
        {
            velocidade = velocidade * 2;
            PodeAtirar = true;
            Lesado = false;
            Acelerado = true;
        }
	}
}