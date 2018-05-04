using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonterScript : MonoBehaviour {
	

	public float speedMonter = 0.001f;

	public int curHealth;
	public Animator anim;
    public Animator spaceMan;
    public GameObject Monster;
	//string MontersJsonData = "";

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
	}
		
	void Update () {

		transform.Translate (speedMonter, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.GetInstanceID());
		if (col.CompareTag("Player")) {
			Healthbar.health -= 100f / 2;
            spaceMan.SetTrigger("gotHit");
        } else if (col.CompareTag("sword")) {
			curHealth -= 5;
			Debug.Log ("hit");
			anim.SetTrigger ("hit");
		} 
        if (curHealth <= 0) {
			Debug.Log ("Monster Die");
			anim.SetTrigger("dead");
            StartCoroutine(Example());
        }
    }

    void DesMonster() {
        Destroy(Monster);
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Destroy(Monster);
    }

	//SHARP
	void Start () {
		//MontersJsonData = PlayerPrefs.GetString ("MontersJson");

		//Debug.Log ("JSON MONTER : "+MontersJsonData);
		//Creature_Mon jsonMonters = JsonUtility.FromJson<Creature_Mon> (MontersJsonData);
		//Debug.Log (jsonMonters.id_mon);
		//Debug.Log (jsonMonters.name_mon+" ID : "+jsonMonters.id_mon+" EXP : "+jsonMonters.exp_mon);

	}

}

