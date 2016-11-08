using UnityEngine;
using System.Collections;

public class spawnRecargaMunicao : MonoBehaviour 
{
    public GameObject[] locaisDasMunicoes;
    public GameObject[] municoes;

	void Start () 
    {
	
	}
	void Update () 
    {
        instanciarMunicoes();
	}


    /// <summary>
    /// Método para instanciar todos as municoes nos locais especificos
    /// Fazer condicional para tempo
    /// </summary>
    private void instanciarMunicoes()
    {
        Instantiate(municoes[0], new Vector2(locaisDasMunicoes[0].transform.position.x, locaisDasMunicoes[0].transform.position.x), Quaternion.identity);
        Instantiate(municoes[1], new Vector2(locaisDasMunicoes[1].transform.position.x, locaisDasMunicoes[1].transform.position.x), Quaternion.identity);
        Instantiate(municoes[2], new Vector2(locaisDasMunicoes[2].transform.position.x, locaisDasMunicoes[2].transform.position.x), Quaternion.identity);
        Instantiate(municoes[3], new Vector2(locaisDasMunicoes[3].transform.position.x, locaisDasMunicoes[3].transform.position.x), Quaternion.identity);
    }
}
