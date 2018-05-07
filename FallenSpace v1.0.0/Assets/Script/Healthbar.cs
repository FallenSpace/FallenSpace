using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour {

	public Animator myAnimator;
	public Rigidbody2D myRigidbody;

	Image HealthBar;
	//float maxHealth = 100f;
	public static float health;
	float  Text_get_hp_f;

	public GameObject spaceMan;

	public Text Text_get_hp;

	//monter die
	string createUserURL = "http://www.bunlab.net/sharp/game/";
	int Text_get_exp_i;
	int id_user;
	//

	void Start () {
		InvokeRepeating("decreaseEverySeconds", 1.0f, 1.0f); // kiw decrease Health every 1 seconds

		//monter die
		string exp = PlayerPrefs.GetString ("exp");
		Text_get_exp_i = int.Parse(exp);
		id_user = PlayerPrefs.GetInt ("id_user");
		//

		string hp = PlayerPrefs.GetString ("hp");
		Text_get_hp_f = float.Parse(hp);
		HealthBar = GetComponent<Image> ();
		//health = maxHealth;
		health = Text_get_hp_f;
	}
	// Update is called once per frame
	void Update () {
		HealthBar.fillAmount = health / Text_get_hp_f;
		Debug.Log (health+" / "+Text_get_hp_f); //show เลือด

		Text_get_hp.text = health.ToString();

		//Get speedStart from Player.cs
		float moveSpeedStart = PlayerPrefs.GetFloat ("moveSpeedStart");
		PlayerPrefs.SetFloat ("die_nowalk", moveSpeedStart); //speed player form Player.cs

		if(health <= 0){
			
			//Destroy (spaceMan, 5);

			myAnimator.SetBool ("death", true);
			myRigidbody.velocity = Vector2.zero;

			PlayerPrefs.SetFloat ("die_nowalk", 0f); //speed player in if

			Debug.Log ("death");
			SceneManager.LoadScene ("scoreSummaryLose");

			//monter die
			Text_get_exp_i = Text_get_exp_i + 50; // exp + 50
			ExpPlus (id_user ,Text_get_exp_i);

		}
	}
	//monter die
	public void ExpPlus(int id_user, int exp){

		WWWForm form = new WWWForm();
		form.AddField("id_userPost", id_user);
		form.AddField("expPost", exp);
		WWW www = new WWW(createUserURL, form);

	}
		
	public void decreaseEverySeconds()  // kiw decrease Health every 1 seconds
	{
		health -= 5; 
	}
	//
}