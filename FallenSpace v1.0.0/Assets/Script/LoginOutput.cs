using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginOutput : MonoBehaviour {

	public Text Text_get_username;
	public Text Text_get_email;
	public Text Text_get_password;
	public Text Text_get_name;
	public Text Text_get_money;
	public Text Text_get_score;
	public Text Text_get_state;
	public Text Text_get_level;
	public Text Text_get_exp;
	public Text Text_get_hp;


	// Use this for initialization
	void Start () {
		string user_name = PlayerPrefs.GetString ("user_name");

		Debug.Log ("LOGINOUT"+user_name);
		Creature jsonuser = JsonUtility.FromJson<Creature> (user_name);
		Debug.Log (jsonuser.id);
		Debug.Log (jsonuser.username);
		Debug.Log (jsonuser.hp);


		Text_get_username.text = jsonuser.username;
		Text_get_email.text = jsonuser.email;
		Text_get_password.text = jsonuser.password;
		Text_get_name.text = jsonuser.name;
		Text_get_money.text = jsonuser.money;
		Text_get_score.text = jsonuser.score;
		Text_get_state.text = jsonuser.state;
		Text_get_level.text = jsonuser.level;
		Text_get_exp.text = jsonuser.exp;
		Text_get_hp.text = jsonuser.hp;

		PlayerPrefs.SetInt ("id_user", jsonuser.id); //ส่งค่า
		PlayerPrefs.SetString ("exp", jsonuser.exp); //ส่งค่า
		PlayerPrefs.SetString ("hp", jsonuser.hp); //ส่งค่า


	}
}
	
[System.Serializable]
public class Creature {
	public int id;
	public string username;
	public string email;
	public string password;
	public string name;
	public string money;
	public string score;
	public string state;
	public string level;
	public string exp;
	public string hp;
}



