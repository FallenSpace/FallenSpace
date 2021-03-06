﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Button Register_But;
	public Button Login_But;
	public Button Play_But;
	public Button State1_But;
	public Button Exit_But;
	public Button Shop_But;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClickRegister () {
		SceneManager.LoadScene ("RegisterPage");
	}

	public void TaskOnClickLogin () {
		SceneManager.LoadScene ("LoginPage");
	}

	public void TaskOnClickPlay () {
		SceneManager.LoadScene ("spaceMan");
	}

	public void TaskOnClickState1 () {
		PlayerValue.sumscorePlayer = 0;
		PlayerValue.scorePlayer = 0;
		PlayerValue.expPlayer = 0; //reset exp player on try again
		SceneManager.LoadScene ("mapTest");
	}

	public void TaskOnClickToMenu () {
		SceneManager.LoadScene ("Main");
	}

	public void TaskOnClickToShop () {
		SceneManager.LoadScene ("SpaceShop");
	}

	public void Exit() {
		Application.Quit();
	}
}
