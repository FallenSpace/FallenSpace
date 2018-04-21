using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginOutput : MonoBehaviour {

	public Text Text_get;

	// Use this for initialization
	void Start () {
		string user_name = PlayerPrefs.GetString ("user_name");
		Text_get.text = user_name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
