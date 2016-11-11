using UnityEngine;
using System.Collections;

public class Selecao : MonoBehaviour {

	public void selecao (int players) {
	
        if (players == 2) {

            Application.LoadLevel("game");
        }

        if (players == 4)
        {

            Application.LoadLevel("game");
        }
    }
}
