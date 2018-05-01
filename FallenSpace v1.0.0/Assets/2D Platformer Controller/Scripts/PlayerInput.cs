using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
		float die_nowalk = PlayerPrefs.GetFloat ("die_nowalk");
		if (die_nowalk == 0f) {
			
		} else {


			Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			player.SetDirectionalInput (directionalInput);

			if (Input.GetButtonDown ("Jump")) {
				player.OnJumpInputDown ();
			}

			if (Input.GetButtonUp ("Jump")) {
				player.OnJumpInputUp ();
			}
		}
    }
}
