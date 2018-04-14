using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DataInserter : MonoBehaviour {

	public string inputUserName;
	public string inputPassword;
	public string inputEmail;

	string createUserURL = "http://www.bunlab.net/sharp/game/InsertUser.php";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
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
