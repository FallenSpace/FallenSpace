using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginCheck : MonoBehaviour {


	public InputField TextUsername;
	public InputField TextPassword;
	public Button Login_btn;

	string inputUserName;
	string inputPassword;
	string inputEmail;




	string createUserURL = "http://www.bunlab.net/sharp/game/InsertUser.php";


	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		inputUserName = TextUsername.text;
		inputPassword = TextPassword.text;
			
		if (Input.GetKeyDown (KeyCode.Return)) { //กด space bar
			CreateUser (inputUserName, inputPassword, inputEmail);
			print ("Send Data Okay");
		}
				
	}

	void TaskOnClick() // คลิกปุ่ม
	{
		if (TextUsername.text == "" && TextPassword.text == "") {
			print ("NO NO NO");
		} else {
			Debug.Log ("clicked the button");
			CreateUser (inputUserName, inputPassword, inputEmail);
			print ("Send Data Okay");
		}
	}

	public void CreateUser(string username, string password, string email){

		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);
		form.AddField("emailPost", email);

		WWW www = new WWW(createUserURL, form);

	}

	//IEnumerator Start () {

	//	WWWForm form = new WWWForm();


	//	form.AddField("usernamePost", "usernameUnity");
	//	form.AddField("passwordPost", "inputpassword");
	//	form.AddField("emailPost", "inputemail");

	//	var download = UnityWebRequest.Post("http://localhost/InsertUser.php", form);

		// Wait until the download is done
	//	yield return download.SendWebRequest();

	//	if (download.isNetworkError || download.isHttpError) {
	//		print( "Error downloading: " + download.error );
	//	} else {
			// show the highscores
	//		Debug.Log(download.downloadHandler.text);
	//	}
	//}

}
