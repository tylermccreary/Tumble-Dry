using UnityEngine;
using System.Collections;

public class PowerJump : MonoBehaviour
{

		private bool powerJump;
		private float powerJumpRadius;
		public LayerMask player;
		GameObject lint;
		private const string JUMP = "jump";

		// Use this for initialization
		void Start ()
		{
				powerJump = false;
				powerJumpRadius = transform.GetComponent<CircleCollider2D> ().radius;
		}
	
		// Update is called once per frame
		void Update ()
		{
				powerJump = Physics2D.OverlapCircle (transform.position, powerJumpRadius, player);
				if (powerJump) {
						SockyController.setPowerJump ();
						Destroy (gameObject);
						PowerUpEffect.Instance.Explosion (transform.position, JUMP);
						powerJump = false;
				}
		}

}
