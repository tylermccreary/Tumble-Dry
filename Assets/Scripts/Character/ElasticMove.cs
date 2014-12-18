using UnityEngine;
using System.Collections;

/** This is a class that controls the elastic that
 * the player shoots.
 **/
public class ElasticMove : MonoBehaviour
{

		private bool faceRight;
		public float shootingForce = 200f;
		private bool forceAdded = false;

		void Update ()
		{
				facingRight ();
				elasticForce ();
		}
	
		void OnCollisionEnter2D (Collision2D coll)
		{
			if (coll.gameObject.layer == 11) {
				LintExplosion.Instance.Explosion (coll.gameObject.transform.position);
				Destroy (coll.gameObject);
			}
			if (coll.gameObject.layer != 8) {
				Destroy (gameObject);
				Shoot.changeElasticNum (-1);
			}
		}

		void elasticForce ()
		{
				if (faceRight && !forceAdded) {
						transform.rigidbody2D.AddForce (new Vector2 (shootingForce, 0));
						forceAdded = true;
				} else if (!faceRight && !forceAdded) {
						transform.rigidbody2D.AddForce (new Vector2 (-1 * shootingForce, 0));
						forceAdded = true;
				}
		}

		void facingRight ()
		{
				faceRight = SockyController.isFacingRight ();
		}
}
