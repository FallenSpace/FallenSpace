using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;
	private bool facingRight;
	private bool attack;

	// Use this for initialization
	void Start () {
		
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();

	}

	void Update(){
		HandleInput ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		HandleMovement (horizontal);
		Flip (horizontal);
		HandleAttacks ();
		resetValues ();
	}

	private void HandleMovement(float Horizontal){
		if(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
			myRigidbody.velocity = new Vector2 (Horizontal * movementSpeed, myRigidbody.velocity.y);
		}
			
		myAnimator.SetFloat ("speed", Mathf.Abs(Horizontal));
		print (Horizontal);
	}

	private void HandleAttacks(){
		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
			myAnimator.SetTrigger ("attack");
			myRigidbody.velocity = Vector2.zero;
		}
	}

	private void HandleInput(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			attack = true;
		}
	}

	private void Flip(float Horizontal){
		if(Horizontal > 0 && !facingRight || Horizontal < 0 && facingRight){
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}
	}


	private void resetValues(){
		attack = false;
	}
}
