using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiScript : MonoBehaviour 
{
    //public Image[] cenoura;
    //public  Image[] berinjela;
    public Image[] abobora;
    //public Image[] brocolis;

	void Start () 
    {
	    
	}
	
    /// <summary>
    /// Verifica quantas recargas foram feitas e mostra o icone completo
    /// </summary>
	void Update () 
    {
        int icone = AboboraScript.icone;

       if(icone >= 1)
       {
           Color c = abobora[0].color;
           c.a = 255;
       }
        if(icone >= 2)
        {
            Color c = abobora[1].color;
            c.a = 255;
        }
        if (icone >= 3)
        {
            Color c = abobora[2].color;
            c.a = 255;
        }
	}
}
