using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour, IEnemy
{
		private Transform player;
		public float stillDelay;
		public float jumpForce = 500f;
		public float jumpDelay;
		public Transform leftWall;
		public Transform rightWall;
		public Transform groundCheck;
		public Transform groundClose;
		public Transform leftCheck;
		public Transform rightCheck;
		public LayerMask whatIsGround;
		public float walkSpeed;
		public GameObject shootPoints;
		public GameObject spikePrefab;
		private float move;
		private const float DIST_FROM_SOCK = 4.0f;
		public Animator anim;
		float groundRadius = 0.2f;
		bool grounded = false;
		private bool inAir = false;
		private string wallDetected = "None";
		private const string LEFT_WALL = "LeftWall";
		private const string RIGHT_WALL = "RightWall";
		private static int health = 10;
		public GameObject healthBar;
		public GameObject goalPrefab;
		private MonoBehaviour thisScript;

		public enum SpiderActionType
		{
				Still,
				Walk,
				WalkAway,
				Jump,
				Land,
				Shoot,
				Die
		}

		private SpiderActionType spiderCurrent = SpiderActionType.Still;

		void Awake ()
		{
				player = GameObject.FindGameObjectWithTag ("Player").transform;

		}

		// Use this for initialization
		void Start ()
		{
				thisScript = (MonoBehaviour)GetComponent ("SpiderController");
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

				case SpiderActionType.Die:
						anim.speed = 1;
						die ();
						break;
				}
		}
		
		IEnumerator stillState ()
		{
				transform.rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
				anim.speed = 1;
				anim.Play ("Still");
				yield return new WaitForSeconds (stillDelay);
				spiderCurrent = SpiderActionType.Walk;
		}

		void walkState ()
		{
				if ((leftCheck.transform.position.x > leftWall.transform.position.x || wallDetected == LEFT_WALL) &&
						(rightCheck.transform.position.x < rightWall.transform.position.x || wallDetected == RIGHT_WALL)) {
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
								spiderCurrent = SpiderActionType.Jump;
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
				if (player.transform.position.x < transform.position.x && wallDetected == LEFT_WALL) {
						//move right
						move = 1.0f;
						transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed * 2, rigidbody2D.velocity.y);
						anim.Play ("WalkReverse");
				} else if (player.transform.position.x > transform.position.x && wallDetected == RIGHT_WALL) {
						//move left
						move = -1.0f;
						transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed * 2, rigidbody2D.velocity.y);
						anim.Play ("Walk");
				} else {
						spiderCurrent = SpiderActionType.Still;
				}
				if (transform.position.x < 0 && wallDetected == RIGHT_WALL ||
						transform.position.x > 0 && wallDetected == LEFT_WALL) {
						/*leftCheck.transform.position.x < leftWall.transform.position.x && wallDetected == RIGHT_WALL ||
				rightCheck.transform.position.x > rightWall.transform.position.x && wallDetected == LEFT_WALL*/
						wallDetected = "None";
						spiderCurrent = SpiderActionType.Still;
				}
		}

		IEnumerator jumpState ()
		{
				anim.Play ("Jump");
				yield return new WaitForSeconds (jumpDelay);
				if (!inAir) {
						inAir = true;
						//this.rigidbody2D.AddForce (new Vector2 (0, jumpForce));
						this.rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 10);
				}
				spiderCurrent = SpiderActionType.Land;
		}

		void landState ()
		{
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
				anim.Play ("SpiderShoot");
				foreach (Transform child in shootPoints.transform) {
						GameObject spike = (GameObject)Instantiate (spikePrefab, new Vector3 (child.transform.position.x, child.transform.position.y, 0), Quaternion.identity);
						SpiderSpike.setSpiderObject (this.transform.gameObject);
				}
				spiderCurrent = SpiderActionType.WalkAway;
		}
	
		public void die ()
		{
				anim.Play ("Die");
				Destroy (healthBar);
				transform.rigidbody2D.velocity = new Vector2 (0, transform.rigidbody2D.velocity.y);
				transform.rigidbody2D.isKinematic = true;
				GameObject goal = (GameObject)Instantiate (goalPrefab, new Vector3 (transform.position.x, transform.position.y + 5, 0), Quaternion.identity);
				thisScript.enabled = false;
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.layer == 8 && spiderCurrent != SpiderActionType.Die) {
						doDamage ();
				}
		}

		public string getEnemyType ()
		{
				return "spider";
		}

		public void takeDamage (int amount)
		{
				health = health - amount;
				if (health <= 0) {
						spiderCurrent = SpiderActionType.Die;
				}
		}

		public void doDamage ()
		{
				SockyController.doDamage (1);
		}

		public static int getHealth ()
		{
				return health;
		}
	
}
