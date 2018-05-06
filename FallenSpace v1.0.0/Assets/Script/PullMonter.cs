using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PullMonter : MonoBehaviour
{

	public static string mons_name;
	public static int mons_money;
	public static int mons_hp;
	public static int mons_exp;
	public static int mons_score;
	public static int mons_attack;

	void Start ()
	{
		StartCoroutine(ReadJsonData());
	}

	IEnumerator ReadJsonData()
	{
		string url = "http://www.bunlab.net/sharp/game/Monters.php";
		WWW www = new WWW(url);
		yield return www;

		if (!string.IsNullOrEmpty(www.error))
		{
			print("Error downloading: " + www.error);
		}
		else
		{
			JsonViewModel mons = JsonUtility.FromJson<JsonViewModel>(www.text);
			Debug.Log(mons.monters_id + " " + mons.monters_name + " " + mons.monters_money);    

			mons_name = mons.monters_name;
			mons_money = mons.monters_money;
			mons_hp = mons.monters_hp;
			mons_exp = mons.monters_exp;
			mons_score = mons.monters_score;
			mons_attack = mons.monters_attack;

			PlayerPrefs.SetString("mons_name", mons_name);
			PlayerPrefs.SetInt ("mons_money", mons_money);
			PlayerPrefs.SetInt ("mons_hp", mons_hp);
			PlayerPrefs.SetInt ("mons_exp", mons_exp);
			PlayerPrefs.SetInt ("mons_score", mons_score);
			PlayerPrefs.SetInt ("mons_attack", mons_attack);

		}
	}
}


public class JsonViewModel
{
	public int monters_id;
	public string monters_name;
	public int  monters_money;
	public int monters_exp;
	public int monters_hp;
	public int monters_score;
	public int monters_attack;
}