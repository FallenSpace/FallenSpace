using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpace : MonoBehaviour {

    private static PlayerSpace instance;
    public static PlayerSpace Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerSpace>();
            }
            return instance;
        }
    }

    private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;
	private bool facingRight;

	[SerializeField]
	private Transform[] groundPoints;
	private float groundRadius;

	private LayerMask whatIsGround;

    public Rigidbody2D MyRigidbody { get; set; }

    public bool Attack { get; set; }
    public bool OnGround { get; set; }


    [SerializeField]
	private float jumpForce;
	// Use this for initialization
	void Start () {

		facingRight = true;
        MyRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();

	}

	void Update(){
		HandleInput ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");

		OnGround = IsGrounded ();

		HandleMovement (horizontal);
		Flip (horizontal);
	}

	private void HandleMovement(float horizontal){
		if(MyRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);
        }
        if (!Attack)
        {
            MyRigidbody.velocity = new Vector2(horizontal * movementSpeed, MyRigidbody.velocity.y);
        }

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
	}


	private void HandleInput(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
            myAnimator.SetTrigger("attack");
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

	private bool IsGrounded(){
		if(MyRigidbody.velocity.y <= 0){
			foreach (Transform point in groundPoints){
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) {
					if(colliders[i].gameObject != gameObject) {
						return true;
					}
				}
			}
		}
		return false;
	}

}