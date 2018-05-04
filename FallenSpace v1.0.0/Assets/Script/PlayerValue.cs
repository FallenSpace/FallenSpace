using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValue : MonoBehaviour {

	int expPlayer = 0 ;
	int scorePlayer = 0;
	int finishgame = 0;

	void Start () {
		int scoreMonter = PlayerPrefs.GetInt ("scoreMonter");
	}

	void Update () {

	}
}
