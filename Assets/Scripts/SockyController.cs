using UnityEngine;
using System.Collections;

public class SockyController : MonoBehaviour {

	public float maxSpeed= 10f;
	static public float jumpForce = 400f;
	public Transform groundCheck;
	float groundRadius = .2f;
	public float finishRadius = 1f;
	public LayerMask whatIsGround;
	public LayerMask whatIsFinish;
	public LayerMask whatIsJump;
	public LayerMask player;
	float characterX;
	float characterY;
	bool grounded = false;
	bool doubleJump = false;
	bool facingRight = true;
	private float move;
	GameObject rotateAround;
	static public float health = 5f;
	private Animator animator;
	private bool jump;
	private int jumpAnimInt;
	private GameObject SockComponents;

	void Awake() {
				animator = GetComponent<Animator> ();
		}

	// Use this for initialization
	void Start () {
		jumpAnimInt = 0;
		SockComponents = GameObject.Find ("SockComponents");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		walkAnim ();
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		move = Input.GetAxis ("Horizontal");
		//move left and right
		SockComponents.rigidbody2D.velocity = new Vector2 (move * maxSpeed, SockComponents.rigidbody2D.velocity.y);
		//flip character
		if (move > 0 && !facingRight) {
				Flip ();
		} else if (move < 0 && facingRight) {
				Flip ();
		}
		isDead ();
	}

	void Update(){
		jumping ();
		jumpAnim ();
		}

	void Flip(){
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void walkAnim(){
				if (move != 0 && grounded) {
						animator.SetBool ("walk", true);
				} else {
						animator.SetBool ("walk", false);
				}
		}

	void jumping(){
				if ((grounded || doubleJump) && Input.GetButtonDown ("Jump")) {
						SockComponents.rigidbody2D.AddForce (new Vector2 (0, jumpForce));
						doubleJump = !doubleJump;
			jump = true;
				}
		}

	void jumpAnim(){
		if (jump) {
			jumpAnimInt = jumpAnimInt + 1;
			animator.SetInteger ("jumpTimes", jumpAnimInt);
		}
		if (!grounded) {
						animator.SetBool ("jump", true);
				} else {
						animator.SetBool ("jump", false);
			jumpAnimInt = 0;
				}


		}

	void isDead(){
				if (health <= 0) {
			Destroy(SockComponents);
				}
		}

}
