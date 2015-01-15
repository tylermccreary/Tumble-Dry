using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour
{
		private Transform player;
		public float stillDelay;
		private Time startTime;
		private Time currentTime;
		public Transform leftWall;
		public Transform rightWall;
		public Transform groundCheck;
		public Transform groundClose;
		public float walkSpeed;
		private float move;
		public Animator anim;


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
						anim.speed = 3;
						walkAway ();
						break;
			
				case SpiderActionType.Jump:
						anim.speed = 1;
						jumpState ();
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

				//if character shot
				//change to jump depending on character height
		}

		IEnumerator stillState ()
		{
				Debug.Log ("stillstate");
				anim.speed = 1;
				anim.Play ("Still");
				yield return new WaitForSeconds (stillDelay);
				spiderCurrent = SpiderActionType.Walk;
		}

		void walkState ()
		{
				Debug.Log ("walkstate");
				//if no wall
				if (player.transform.position.x < transform.position.x) {
						//move left
						move = -1.0f;
						transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed, rigidbody2D.velocity.y);
						anim.Play ("Walk");
				} else {
						//move right
						move = 1.0f;
						transform.rigidbody2D.velocity = new Vector2 (move * walkSpeed, rigidbody2D.velocity.y);
						anim.Play ("WalkReverse");
				}
				//else
				//shoot
				//change to walkAwayState
		}

		void walkAway ()
		{
				//walk to opposite side of player
				//still state
		}

		void jumpState ()
		{
				//jump anim
				//add jump force
				//wait for landing (use ground object)
				//land
		}

		void landState ()
		{
				//land
				//walk toward player
		}

		void shootState ()
		{
				//shoot
				//walkaway
		}

}
