using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour
{
		private Transform player;
		public float stillDelay;
		public float jumpForce = 500f;
		public float jumpDelay;
		private Time startTime;
		private Time currentTime;
		public Transform leftWall;
		public Transform rightWall;
		public Transform groundCheck;
		public Transform groundClose;
		public Transform leftCheck;
		public Transform rightCheck;
		public float walkSpeed;
		private float move;
		private const float DIST_FROM_SOCK = 4.0f;
		public Animator anim;
		float groundRadius = 0.2f;
		public LayerMask whatIsGround;
		bool grounded = false;
		private bool living = true;
		private bool inAir = false;
		private string wallDetected = "None";
		private const string LEFT_WALL = "LeftWall";
		private const string RIGHT_WALL = "RightWall";


		public enum SpiderActionType
		{
				Still,
				Walk,
				WalkAway,
				Jump,
				Land,
				Shoot
		}

		private SpiderActionType spiderCurrent = SpiderActionType.Still;

		void Awake ()
		{
				player = GameObject.FindGameObjectWithTag ("Player").transform;

		}

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				switch (spiderCurrent) {
				case SpiderActionType.Still:
						anim.speed = 1;
						StartCoroutine (stillState ());
						break;
			
				case SpiderActionType.Walk:
						anim.speed = 3;
						walkState ();
						break;

				case SpiderActionType.WalkAway:
						anim.speed = 6;
						walkAway ();
						break;
			
				case SpiderActionType.Jump:
						anim.speed = 1;
						StartCoroutine (jumpState ());
						break;
			
				case SpiderActionType.Land:
						anim.speed = 1;
						landState ();
						break;
			
				case SpiderActionType.Shoot:
						anim.speed = 1;
						shootState ();
						break;
				}
				/**if (spiderCurrent == SpiderActionType.Jump) {
						spiderCurrent = SpiderActionType.Land;
				} else {
						grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
						//if character shot
						if (Shoot.getElasticNum () != 0 && grounded) {
								spiderCurrent = SpiderActionType.Jump;
						}
				}*/
		}
		
		IEnumerator stillState ()
		{
				anim.speed = 1;
				anim.Play ("Still");
				yield return new WaitForSeconds (stillDelay);
				spiderCurrent = SpiderActionType.Walk;
		}

		void walkState ()
		{
				if (leftCheck.transform.position.x > leftWall.transform.position.x &&
						rightCheck.transform.position.x < rightWall.transform.position.x) {
						if (player.transform.position.x < transform.position.x - DIST_FROM_SOCK) {
								//move left
								move = -1.0f;
								transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed, rigidbody2D.velocity.y);
								anim.Play ("Walk");
						} else if (player.transform.position.x > transform.position.x + DIST_FROM_SOCK) {
								//move right
								move = 1.0f;
								transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed, rigidbody2D.velocity.y);
								anim.Play ("WalkReverse");
						} else {
								anim.Play ("Still");
						}
				} else {
						if (leftCheck.transform.position.x < leftWall.transform.position.x) {
								wallDetected = LEFT_WALL;
						} else {
								wallDetected = RIGHT_WALL;
						}
						spiderCurrent = SpiderActionType.Shoot;
				}
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				//if character shot
				if (Shoot.getElasticNum () != 0 && grounded) {
						spiderCurrent = SpiderActionType.Jump;
				}
		}
	
		void walkAway ()
		{
				if (player.transform.position.x < transform.position.x) {
						//move left
						move = 1.0f;
						transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed * 2, rigidbody2D.velocity.y);
						anim.Play ("WalkReverse");
				} else if (player.transform.position.x > transform.position.x) {
						//move right
						move = -1.0f;
						transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed * 2, rigidbody2D.velocity.y);
						anim.Play ("Walk");
				}
				if (transform.position.x < 0 && wallDetected == RIGHT_WALL ||
						transform.position.x > 0 && wallDetected == LEFT_WALL) {
						/*leftCheck.transform.position.x < leftWall.transform.position.x && wallDetected == RIGHT_WALL ||
				rightCheck.transform.position.x > rightWall.transform.position.x && wallDetected == LEFT_WALL*/
						Debug.Log ("Hello");
						spiderCurrent = SpiderActionType.Still;
				}
		}

		IEnumerator jumpState ()
		{
				anim.Play ("Jump");
				yield return new WaitForSeconds (jumpDelay);
				if (!inAir) {
						inAir = true;
						this.rigidbody2D.AddForce (new Vector2 (0, jumpForce));
				}
				spiderCurrent = SpiderActionType.Land;
		}

		void landState ()
		{
				//land
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				if (grounded) {
						inAir = false;
						anim.Play ("Land");
						spiderCurrent = SpiderActionType.Walk;
				}
		}

		void shootState ()
		{
				//shoot
		
				spiderCurrent = SpiderActionType.WalkAway;
		}
	
}
