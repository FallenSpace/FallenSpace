using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValue : MonoBehaviour {

	public static int expPlayer = 0 ;
	public static int scorePlayer = 0;
	public static int sumscorePlayer;
	void Start () {

	}

	void Update () {
		//scorePlayer = scorePlayer + scoreMonter;
		//Debug.Log (scorePlayer);
		//PlayerPrefs.SetInt ("scorePlayer", scorePlayer);

		sumscorePlayer = scorePlayer;

	}
}
