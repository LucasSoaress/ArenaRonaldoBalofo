using UnityEngine;
using System.Collections;

public class BeringelaScript : MonoBehaviour
{
	
	public GameObject Beringela;
	public float velocidade;
	public float MaxX;
	public float MinX;
	public float MaxY;
	public float MinY;
	
	//Vida
	public static int HealthBeringela;
	
	
	// Use this for initialization
	void Start() {
		
		HealthBeringela = 100;
		
	}
	
	// Update is called once per frame
	void Update()
	{
		Move();
		Vida();
	}
	
	void Vida()
	{
		
		if (HealthBeringela <= 0)
		{
			Destroy(Beringela);
		}
	}
	
	void Move()
	{
		
		float TranslationY = Input.GetAxisRaw("P1_Vertical") * velocidade * Time.deltaTime;
		Beringela.transform.Translate(0, TranslationY, 0);
		
		float TranslationX = Input.GetAxisRaw("P1_Horizontal") * velocidade * Time.deltaTime;
		Beringela.transform.Translate(TranslationX, 0, 0);
		
	}
	
	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Lama")
		{
			velocidade = 1;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{ 
		velocidade = 3;
	}
	
}