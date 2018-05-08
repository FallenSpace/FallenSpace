using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValue : MonoBehaviour {

	public Text score;

	public static int expPlayer = 0 ;
	public static int scorePlayer = 0;
	public static int moneyPlayer = 0; // new money
	public static int sumscorePlayer,sumexpPlayer,summoneyPlayer;
	int UserId,UserScore,UserExp,UserMoney; // old
	string UserUsername,UserPassword,userpullText;


	string createUserURL = "http://www.bunlab.net/sharp/game/CheckLogin.php";
	string createURL = "http://www.bunlab.net/sharp/game/InsertScore.php";


	void Start () {

		UserId = PlayerPrefs.GetInt ("id_user");
		//UserScore = PlayerPrefs.GetInt ("score");
		//UserExp = PlayerPrefs.GetInt ("exp");
		UserPassword = PlayerPrefs.GetString ("password");
		UserUsername = PlayerPrefs.GetString ("username");
		//ดึงข้อมูลสกอ ล่าสุด 
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", UserUsername);
		form.AddField("passwordPost", UserPassword);

		WWW www_checkagian = new WWW(createUserURL, form);
		StartCoroutine(checkagian(www_checkagian));
	
	}


	void Update () {
	}

	void HighScore (){
		WWWForm form = new WWWForm ();
		form.AddField ("idPost", UserId);
		form.AddField ("scorePost", sumscorePlayer);
		form.AddField ("expPost", sumexpPlayer); // exp
		form.AddField ("moneyPost", summoneyPlayer); //money
		WWW www = new WWW (createURL, form);
		Debug.Log ("high score"); 
	}

	void LowScore (){
		WWWForm form = new WWWForm ();
		form.AddField ("idPost", UserId);
		form.AddField ("scorePost", UserScore);
		form.AddField ("expPost", sumexpPlayer); // exp
		form.AddField ("moneyPost", summoneyPlayer); //money
		WWW www = new WWW (createURL, form);
		Debug.Log ("low score"); 
	}




	private IEnumerator checkagian(WWW _w) { // ดึงข้อมูล user ใหม่เพราะต้องการสกอและ exp ที่ใหม่
		yield return _w;
		if(_w.error == null){
			if(_w.text == "Log in successful!"){
				//What happens to the player when he logs in:
			}else {
				userpullText = _w.text;
			}
		}else {
			userpullText  = "Error" + _w.error;
		}
		print("CHECKAGAIN"+userpullText );

		Creature_PullUserAgain jsonuser_again = JsonUtility.FromJson<Creature_PullUserAgain> (userpullText);

		//ค่าที่มาจาก dataBase
		UserScore = jsonuser_again.score;
		UserExp = jsonuser_again.exp;
		UserMoney = jsonuser_again.money;

		/////////////////////////////////////////////////////////////

		//StartCoroutine(Delay());
		int scoreState = MonterScript.scoreState; 
		sumscorePlayer = scorePlayer+scoreState;
		score.text = sumscorePlayer.ToString(); //SHOW SCORE เก่า

		sumexpPlayer = expPlayer + UserExp;

		summoneyPlayer = moneyPlayer + UserMoney;
			
		Debug.Log ("EXP Player  "+sumexpPlayer);

		Debug.Log (sumscorePlayer+" > "+UserScore);
		if (sumscorePlayer > UserScore) { // ถ้าสกอมากกว่าที่มีให้เอาสกอใหม่ไปเก็บ
			HighScore ();
		} else {
			LowScore ();
		}
		/////////////////////////////////////////////////////////////


	}


	IEnumerator Delay()
	{
		yield return new WaitForSeconds(2);
	}


}

public class Creature_PullUserAgain {
	public int score;
	public int exp;
	public int money;
}