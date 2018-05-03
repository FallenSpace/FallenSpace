using System.Collections;
using UnityEngine;

public class MonterScript : MonoBehaviour {

	string MontersURL = "http://www.bunlab.net/sharp/game/monters.php";
	public float speedMonter = 0.001f;

	public int curHealth;
	public Animator anim;
    public Animator spaceMan;
    public GameObject Monster;

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (speedMonter, 0, 0);

	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log (col.GetInstanceID());
		if (col.CompareTag("Player")) {
			Healthbar.health -= 100f / 2;
            spaceMan.SetTrigger("gotHit");
        } else if (col.CompareTag("sword")) {
			curHealth -= 5;
			Debug.Log ("hit");
			anim.SetTrigger ("hit");
		} 
        if (curHealth <= 0) {
			Debug.Log ("Monster Die");
			anim.SetTrigger("dead");
            StartCoroutine(Example());
        }
    }

    void DesMonster() {
        Destroy(Monster);
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Destroy(Monster);
    }
}
	
