using UnityEngine;
using System.Collections;

public class SockyController : MonoBehaviour, IHealthy
{
		public float maxSpeed = 10f;
		private float speed;
		private static float jumpForce = 400f;
		private static bool powerJump = false;
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
		private static bool facingRight = true;
		private static int health = 5;
		private float move;
		private float duck;
		private Animator animator;
		private bool jump;
		private int jumpAnimInt;
		private GameObject SockComponents;
		private float timerPrev;
		private float timerNow;
		private float jumpSinRatio;
		private float timerDif;
		private const float POWER_JUMP_RATIO = 1.2f;
		private static bool living = true;

		void Start ()
		{
				timerPrev = 0;
				animator = GetComponent<Animator> ();
				jumpAnimInt = 0;
				SockComponents = GameObject.Find ("SockComponents");
				speed = maxSpeed;
		}

		void FixedUpdate ()
		{
				move = Input.GetAxis ("Horizontal");
				SockComponents.rigidbody2D.velocity = new Vector2 (move * speed, SockComponents.rigidbody2D.velocity.y);
				facingDirection ();
				isDead ();
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				playerFriction ();
				jumpSin ();
		}

		void Update ()
		{
				jumping ();
				walkAnim ();
				jumpAnim ();
				ducking ();
		}

		void facingDirection ()
		{
				if (move > 0 && !facingRight) {
						flip ();
				} else if (move < 0 && facingRight) {
						flip ();
				}
		}

		void flip ()
		{
				facingRight = !facingRight;
				Vector2 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}

		void walkAnim ()
		{
				if (move != 0 && grounded) {
						animator.SetBool ("walk", true);
				} else {
						animator.SetBool ("walk", false);
				}
		}

		void jumping ()
		{
				if (grounded && Input.GetButtonDown ("Jump")) {
						SockComponents.rigidbody2D.AddForce (new Vector2 (0, jumpForce));
						doubleJump = true;
						jump = true;
						timerPrev = Time.time;
				} else if (doubleJump && Input.GetButtonDown ("Jump")) {
						SockComponents.rigidbody2D.AddForce (new Vector2 (0, jumpForce * jumpSinRatio));
						doubleJump = false;
						jump = true;
				}
		}

		void jumpAnim ()
		{
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

		void jumpSin ()
		{
				timerNow = Time.time;
				timerDif = (timerNow - timerPrev);
				if (timerDif < 1) {
						jumpSinRatio = Mathf.Sin (timerDif) * 2.5f;
				} else {
						jumpSinRatio = 1;
				}
		}

		void ducking ()
		{
				duck = Input.GetAxis ("Vertical");
				if (grounded && duck < 0) {
						animator.SetBool ("duck", true);
						speed = 0.6f * maxSpeed;
				} else {
						animator.SetBool ("duck", false);
						speed = maxSpeed;
				}
		}

		void playerFriction ()
		{
				if (!grounded) {
						transform.collider2D.sharedMaterial.friction = 0.0f;
				} else {
						transform.collider2D.sharedMaterial.friction = 0.5f;
				}
		}

		void isDead ()
		{
				if (health <= 0) {
						living = false;
						Destroy (SockComponents);
				}
		}

		public static bool getPowerJump ()
		{
				return powerJump;
		}

		public static void setPowerJump ()
		{
				if (!powerJump) {
						jumpForce = jumpForce * POWER_JUMP_RATIO;
				}
				powerJump = true;
		}

		public static void doDamage (int amount)
		{
				health -= amount;
		}

		public static bool isFacingRight ()
		{
				return facingRight;
		}

		public int getHealth ()
		{
				return health;
		}

		public static bool isAlive ()
		{
				return living;
		}
}
