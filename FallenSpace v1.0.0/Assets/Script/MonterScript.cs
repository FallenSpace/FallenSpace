using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterScript : MonoBehaviour {

	string MontersURL = "http://www.bunlab.net/sharp/game/monters.php";
	public float speedMonter = 0.001f;

	public int curHealth;
	public Animator anim;

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		if(curHealth <= 0){
			Debug.Log("dieee");
		}
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (speedMonter, 0, 0);

	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.GetInstanceID());
		if (col.GetInstanceID () == -50742) {
			Healthbar.health -= 100f / 2;
		} else if (col.GetInstanceID () == -64132) {
			curHealth -= 5;
			Debug.Log ("hit");
			anim.SetTrigger ("hit");
		} else if (curHealth <= 0) {
			Debug.Log ("Monster Die");
			anim.SetBool ("dead", true);
		} 

	}

}
	
