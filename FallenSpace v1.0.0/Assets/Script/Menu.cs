using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Button Register_But;
	public Button Login_But;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClickRegister () {
		SceneManager.LoadScene ("RegsiterPage");
	}

	public void TaskOnClickLogin () {
		SceneManager.LoadScene ("LoginPage");
	}

}
