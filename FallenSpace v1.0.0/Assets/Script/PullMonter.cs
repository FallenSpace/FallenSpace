using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Newtonsoft.Json;

public class PullMonter : MonoBehaviour {
	
	string MontersJson = "";
	string MontersURL = "http://www.bunlab.net/sharp/game/Monters.php";

	void Start () {
		WWWForm form = new WWWForm();
		WWW www = new WWW(MontersURL, form);
		StartCoroutine(MontersWWW(www));
		StartCoroutine(Example());
	}

	void Update () {}

	IEnumerator Example() {
		
		yield return new WaitForSeconds(2);
		string MontersJsonData = PlayerPrefs.GetString ("MontersJson");

		Debug.Log ("JSON MONTER : "+MontersJsonData);
		Creature_Mon jsonMonters = JsonUtility.FromJson<Creature_Mon> (MontersJsonData);
		//Creature_Mon jsonMonters = Newtonsoft.Json.JsonConvert.DeserializeObject<Creature_Mon> (MontersJsonData);

		Debug.Log (jsonMonters.id_mon);
		Debug.Log (jsonMonters.name_mon);
		//Debug.Log (jsonMonters.name_mon+" ID : "+jsonMonters.id_mon+" EXP : "+jsonMonters.exp_mon);
	}

		

	private IEnumerator MontersWWW(WWW www_MontersJson) {
		yield return www_MontersJson;
		//if (www_MontersJson.error == null){
		if (string.IsNullOrEmpty(www_MontersJson.error)){
				MontersJson = www_MontersJson.text;
		}else {
			MontersJson = "Error" + www_MontersJson.error;
		}
		PlayerPrefs.SetString ("MontersJson", MontersJson); //ส่งค่า


	}



}

[System.Serializable]
public class Creature_Mon {

	public string id_mon;
	public string name_mon;
	public string money_mon;
	public string exp_mon;
	public string hp_mon;
	public string score_mon;
	public string attack_mon;
	/*
	public int monters_id { get; set; }
	public string monters_name { get; set; }
	public string monters_money { get; set; }
	public string monters_exp { get; set; }
	public string monters_hp { get; set; }
	public string monters_score { get; set; }
	public string monters_attack { get; set; }
	*/
}
