using UnityEngine;
using System.Collections;

public class screenAdjust : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Camera.main.aspect = 1440f / 900f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
