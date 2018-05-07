using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginCheck : MonoBehaviour {

	public InputField TextUsername;
	public InputField TextPassword;
	public Button Login_btn;

	string inputUserName;
	string inputPassword;
	string inputEmail;

	string MenuText = "";
	public Text Text_get;


	string createUserURL = "http://www.bunlab.net/sharp/game/CheckLogin.php";



	void Start () {

	}

	// Update is called once per frame
	void Update () {

		inputUserName = TextUsername.text;
		inputPassword = TextPassword.text;
			
		if (Input.GetKeyDown (KeyCode.Return)) { //กด space bar
			CreateUser (inputUserName, inputPassword);
			print ("Send Data Okay");

		}
			
				
	}

	public void TaskOnClick() // คลิกปุ่ม
	{
		if (TextUsername.text == "" && TextPassword.text == "") {
			print ("NO NO NO");
		} else {
			Debug.Log ("clicked the button");
			CreateUser (inputUserName, inputPassword);
			print ("Send Data Okay");

			StartCoroutine(Example());


			//Text_get.text = MenuText;
		}
	}

	IEnumerator Example()
	{
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
		print (MenuText);
	}

	public void CreateUser(string username, string password){

		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("passwordPost", password);

		WWW www = new WWW(createUserURL, form);
		StartCoroutine(Login(www));

	}

	private IEnumerator Login(WWW _w) {
		yield return _w;
		if(_w.error == null){
			if(_w.text == "Log in successful!"){
				//What happens to the player when he logs in:
			}else {
				MenuText = _w.text;
			}
		}else {
			MenuText = "Error" + _w.error;
		}
		print("LOGINCHECK"+MenuText);

		if (MenuText == "Username and Password Incorrect!!!LEVEL ERROR!!null") { //ถ้าพาสผิด
			MenuText = "Username and Password Incorrect";
			Text_get.text = MenuText;
		} else {
			SceneManager.LoadScene ("Play"); //เปลี่ยนซีน
		}

		PlayerPrefs.SetString ("user_name", MenuText); //ส่งค่า
	}


}
