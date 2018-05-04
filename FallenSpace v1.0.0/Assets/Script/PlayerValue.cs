using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValue : MonoBehaviour {

	public Text score;

	public static int expPlayer = 0 ;
	public static int scorePlayer = 0;
	public static int sumscorePlayer;
	int UserId,UserScore;


	string createUserURL = "http://www.bunlab.net/sharp/game/InsertScore.php";


	void Start () {
		UserId = PlayerPrefs.GetInt ("id_user");
		UserScore = PlayerPrefs.GetInt ("score");
	}

	void Update () {
		
		int scoreState = MonterScript.scoreState; 
		sumscorePlayer = scorePlayer+scoreState;
		score.text = sumscorePlayer.ToString();

		if (sumscorePlayer > UserScore) {
			WWWForm form = new WWWForm ();
			form.AddField ("idPost", UserId);
			form.AddField ("scorePost", sumscorePlayer);
			WWW www = new WWW (createUserURL, form);
		} else {
			Debug.Log ("low score");
		}

	}
}
