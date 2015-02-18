using UnityEngine;
using System.Collections;

public class PowerJump : MonoBehaviour
{

		private bool powerJump;
		private float powerJumpRadius;
		public LayerMask player;
		GameObject lint;
		private const string JUMP = "jump";

		void Start ()
		{
				powerJump = false;
				powerJumpRadius = transform.GetComponent<CircleCollider2D> ().radius;
		}

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
