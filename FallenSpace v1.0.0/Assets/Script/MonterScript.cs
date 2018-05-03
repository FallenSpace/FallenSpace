using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterScript : MonoBehaviour {

	string MontersURL = "http://www.bunlab.net/sharp/game/monters.php";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Healthbar.health -= 100f/2;
	}

}
	
