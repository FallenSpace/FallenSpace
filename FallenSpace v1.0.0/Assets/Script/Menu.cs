using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Button Register_But;
	public Button Login_But;
	public Button Play_But;
	public Button State1_But;
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

	public void TaskOnClickPlay () {
		SceneManager.LoadScene ("spaceMan");
	}

	public void TaskOnClickState1 () {
		SceneManager.LoadScene ("map1");
	}

}
