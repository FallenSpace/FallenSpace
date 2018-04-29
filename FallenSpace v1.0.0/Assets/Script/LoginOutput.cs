using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginOutput : MonoBehaviour {

	public Text Text_get;


	// Use this for initialization
	void Start () {
		string user_name = PlayerPrefs.GetString ("user_name");

		Debug.Log ("LOGINOUT"+user_name);
		Creature jsonuser = JsonUtility.FromJson<Creature> (user_name);
		Debug.Log (jsonuser.id);
		Debug.Log (jsonuser.username);

		Text_get.text = "HELLO " + jsonuser.username;
	}
}
	
[System.Serializable]
public class Creature {
	public int id;
	public string username;
	public string email;
}

