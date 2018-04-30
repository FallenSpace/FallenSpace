using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
	

	Image HealthBar;
	//float maxHealth = 100f;
	public static float health;
	float  Text_get_hp_f;
	public GameObject spaceMan;

	public Text Text_get_hp;

	// Use this for initialization
	void Start () {
		
		string Text_get_hp = PlayerPrefs.GetString ("hp");
		Text_get_hp_f = float.Parse(Text_get_hp);

		HealthBar = GetComponent<Image> ();
		//health = maxHealth;
		health = Text_get_hp_f;
	}

	// Update is called once per frame
	void Update () {
		HealthBar.fillAmount = health / Text_get_hp_f;
		Debug.Log (health);

		Text_get_hp.text = health.ToString();

		if(health <= 0){
			Destroy (spaceMan, 5);

		}
	}
}