using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour, IEnemy, IHealthy
{
		public float stillDelay;
		public float jumpForce = 500f;
		public float jumpDelay;
		public float walkSpeed;
		private Transform player;
		public Transform leftWall;
		public Transform rightWall;
		public Transform groundCheck;
		public Transform leftCheck;
		public Transform rightCheck;
		public LayerMask whatIsGround;
		public GameObject shootPoints;
		public GameObject spikePrefab;
		public GameObject healthBar;
		public GameObject goalPrefab;
		private float move;
		private const float DIST_FROM_SOCK = 4.0f;
		public Animator anim;
		private float groundRadius = 0.2f;
		private bool grounded = false;
		private bool inAir = false;
		private static int health = 10;
		private MonoBehaviour thisScript;
		private string wallDetected = "None";
		private const string LEFT_WALL = "LeftWall";
		private const string RIGHT_WALL = "RightWall";
		private const string NO_WALL = "None";
		private const string PLAYER = "Player";
		private const string SPIDER_CTRL = "SpiderController";
		private const string ANIM_STILL = "Still";
		private const string ANIM_JUMP = "Jump";
		private const string ANIM_LAND = "Land";
		private const string ANIM_DIE = "Die";
		private const string ANIM_WALK = "Walk";
		private const string ANIM_WALK_REVERSE = "WalkReverse";
		private const string ANIM_SHOOT = "SpiderShoot";

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
				player = GameObject.FindGameObjectWithTag (PLAYER).transform;

		}

		// Use this for initialization
		void Start ()
		{
				thisScript = (MonoBehaviour)GetComponent (SPIDER_CTRL);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (!SockyController.isAlive ()) {
						spiderCurrent = SpiderActionType.Still;
				}
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
				anim.Play (ANIM_STILL);
				yield return new WaitForSeconds (stillDelay);
				spiderCurrent = SpiderActionType.Walk;
		}

		void walkState ()
		{
				if ((leftCheck.transform.position.x > leftWall.transform.position.x || wallDetected == LEFT_WALL) &&
						(rightCheck.transform.position.x < rightWall.transform.position.x || wallDetected == RIGHT_WALL)) {
						if (player.transform.position.x < transform.position.x - DIST_FROM_SOCK) {
								moveLeft (1);
						} else if (player.transform.position.x > transform.position.x + DIST_FROM_SOCK) {
								moveRight (1);
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
				if (Shoot.getElasticNum () != 0 && grounded) {
						spiderCurrent = SpiderActionType.Jump;
				}
		}
	
		void walkAway ()
		{
				if (player.transform.position.x < transform.position.x && wallDetected == LEFT_WALL) {
						moveRight (2);
				} else if (player.transform.position.x > transform.position.x && wallDetected == RIGHT_WALL) {
						moveLeft (2);
				} else {
						spiderCurrent = SpiderActionType.Still;
				}
				if (transform.position.x < 0 && wallDetected == RIGHT_WALL ||
						transform.position.x > 0 && wallDetected == LEFT_WALL) {
						wallDetected = NO_WALL;
						spiderCurrent = SpiderActionType.Still;
				}
		}

		IEnumerator jumpState ()
		{
				anim.Play (ANIM_JUMP);
				yield return new WaitForSeconds (jumpDelay);
				if (!inAir) {
						inAir = true;
						if (spiderCurrent != SpiderActionType.Die) {
								this.rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 10);
						}
				}
				spiderCurrent = SpiderActionType.Land;
		}

		void landState ()
		{
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				if (grounded) {
						inAir = false;
						anim.Play (ANIM_LAND);
						spiderCurrent = SpiderActionType.Walk;
				}
		}

		void shootState ()
		{
				anim.Play (ANIM_SHOOT);
				foreach (Transform child in shootPoints.transform) {
						GameObject spike = (GameObject)Instantiate (spikePrefab, new Vector3 (child.transform.position.x, child.transform.position.y, 0), Quaternion.identity);
						SpiderSpike.setSpiderObject (this.transform.gameObject);
				}
				spiderCurrent = SpiderActionType.WalkAway;
		}

		void moveLeft (int speed)
		{
				move = -1.0f;
				transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed * speed, rigidbody2D.velocity.y);
				anim.Play (ANIM_WALK);
		}

		void moveRight (int speed)
		{
				move = 1.0f;
				transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed * speed, rigidbody2D.velocity.y);
				anim.Play (ANIM_WALK_REVERSE);
		}
	
		public void die ()
		{
				anim.Play (ANIM_DIE);
				Destroy (healthBar);
				transform.rigidbody2D.velocity = new Vector2 (0, -10);
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

		public void takeDamage (int amount)
		{
				health = health - amount;
				if (health <= 0) {
						spiderCurrent = SpiderActionType.Die;
				}
		}

		public void doDamage ()
		{
				if (spiderCurrent != SpiderActionType.Die) {
						SockyController.doDamage (1);
				}
		}

		public int getHealth ()
		{
				return health;
		}
	
}
