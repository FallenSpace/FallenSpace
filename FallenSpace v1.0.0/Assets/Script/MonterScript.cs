using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonterScript : MonoBehaviour {
	

	public float speedMonter = 0.001f;

	//public int curHealth;
	public Animator anim;
    public Animator spaceMan;
    public GameObject Monster;
	string MontersJsonData = "";
	//int scoreMonter = 50;
	//int expMonter = 50;
	public static int scoreState = 100;

	string mons_name;
	int mons_money;
	int mons_hp;
	int mons_exp;
	int mons_score;
	int mons_attack;

	void Start () {

		//PUllMonter Script
		mons_name = PlayerPrefs.GetString("mons_name");
		mons_money = PlayerPrefs.GetInt ("mons_money");
		mons_hp = PlayerPrefs.GetInt ("mons_hp");
		mons_exp = PlayerPrefs.GetInt ("mons_exp");
		mons_score = PlayerPrefs.GetInt ("mons_score");
		mons_attack = PlayerPrefs.GetInt ("mons_attack");
		//

	}


	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
	}
		
	void Update () {



		transform.Translate (speedMonter, 0, 0);
		PlayerPrefs.GetInt ("");
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.GetInstanceID());
		if (col.CompareTag("Player")) {
			//Healthbar.health -= 50f;
			Healthbar.health -= mons_attack;
            spaceMan.SetTrigger("gotHit");
        } else if (col.CompareTag("sword")) {
			mons_hp -= 75;
			Debug.Log ("HPmon : "+mons_hp);
			Debug.Log ("hit");
			anim.SetTrigger ("hit");
		}
		if (mons_hp <= 0) {
			Debug.Log ("Monster Die");
			anim.SetTrigger("dead");
			StartCoroutine(mons_DIE());
        }

    }

	IEnumerator mons_DIE()
    {
        yield return new WaitForSeconds(1);
        Destroy(Monster);
		increaseHealth();
		PlayerValue.scorePlayer += mons_score;
		PlayerValue.expPlayer += mons_exp;

		Debug.Log (" SCORE "+PlayerValue.scorePlayer+" EXP "+PlayerValue.expPlayer);
    }
		
	public void increaseHealth()
	{
		Healthbar.health += 20;
	}
		



}