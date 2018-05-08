﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public Text Text_get_hp_level;
	public Text Text_get_attack_level;
	public Text Text_get_exp_level;

	public Text Text_get_id_item;
	public Text Text_get_name_item;
	public Text Text_get_type_item;
	public Text Text_get_money_item;
	public Text Text_get_value_item;


	// Use this for initialization
	void Start () {
		string user_name = PlayerPrefs.GetString ("user_name");

		//CHECK CONNECT TO SERVER
		if(user_name == "ErrorCannot resolve destination host"){
			SceneManager.LoadScene ("Connect_error"); //เปลี่ยนซีน
		}
		//

		Debug.Log ("LOGINOUT"+user_name);
		Creature jsonuser = JsonUtility.FromJson<Creature> (user_name);
		Debug.Log ("User ID "+jsonuser.id+"U_NAME "+jsonuser.username+"U_hp "+jsonuser.hp_level+"U_SCORE "+jsonuser.score);

		Text_get_username.text = jsonuser.username;
		Text_get_email.text = jsonuser.email;
		Text_get_password.text = jsonuser.password;
		Text_get_name.text = jsonuser.name;
		Text_get_money.text = jsonuser.money;
		Text_get_score.text = jsonuser.score;
		Text_get_state.text = jsonuser.state;
		Text_get_level.text = jsonuser.level;
		Text_get_exp.text = jsonuser.exp;

		Text_get_hp_level.text = jsonuser.hp_level; // ดึงจาก level
		Text_get_attack_level.text = jsonuser.attack_level.ToString(); // ดึงจาก level
		Text_get_exp_level.text = jsonuser.exp_level.ToString(); // ดึงจาก level

		Text_get_id_item.text = jsonuser.id_item.ToString(); //ดึงจาก item
		Text_get_name_item.text = jsonuser.name_item.ToString(); //ดึงจาก item
		Text_get_type_item.text = jsonuser.type_item.ToString(); //ดึงจาก item
		Text_get_money_item.text = jsonuser.money_item.ToString(); //ดึงจาก item
		Text_get_value_item.text = jsonuser.value_item.ToString(); //ดึงจาก item

		PlayerPrefs.SetInt ("id_user", jsonuser.id); //ส่งค่า
		PlayerPrefs.SetString ("exp", jsonuser.exp); //ส่งค่า
		PlayerPrefs.SetString ("score", jsonuser.score); //ส่งค่า

		PlayerPrefs.SetString("username", jsonuser.username);
		PlayerPrefs.SetString ("password", jsonuser.password);

		PlayerPrefs.SetString ("hp", jsonuser.hp_level); //ส่งค่า
		PlayerPrefs.SetInt ("attack_level", jsonuser.attack_level); //ส่งค่า
		PlayerPrefs.SetInt ("exp_level", jsonuser.exp_level); //ส่งค่า
	}
}
	
//[System.Serializable]
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

	public string hp_level;
	public int attack_level;
	public int exp_level;

	public int id_item;
	public int name_item;
	public int type_item;
	public int money_item;
	public int value_item;
}



