using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour {
    	

	public void Menu (int menu) {

        Application.LoadLevel(menu);
	}

    public void Sair() {
        Application.Quit();
    }
}
