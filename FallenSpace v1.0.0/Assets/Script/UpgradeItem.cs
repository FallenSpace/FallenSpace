using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour {

	string InsertMoneyURL = "http://www.bunlab.net/sharp/game/InsertMoney.php";

	int money_user, money_item, summoney_user,UserId, item_user;
	public Text message;

	void Start () {
		
	}

	void Update () {
		UserId = PlayerPrefs.GetInt ("id_user");
		money_user = PlayerPrefs.GetInt ("money_user");
		money_item = PlayerPrefs.GetInt ("money_item");
		item_user = PlayerPrefs.GetInt ("item_user");
	}

	public void TaskOnClickUpGrade() { // คลิกปุ่ม

		if (money_user < money_item) {
			message.text = "You don't have money";
		} else {
			summoney_user = money_user - money_item;
			item_user = item_user+1; // เพิ่มเลเวล
			message.text = "Success";

			WWWForm form = new WWWForm ();
			form.AddField ("idPost", UserId);
			form.AddField ("moneyPost", summoney_user); //money
			form.AddField ("itemPost", item_user);
			WWW www = new WWW (InsertMoneyURL, form);
			Debug.Log ("high score"); 



		}

	}
}
