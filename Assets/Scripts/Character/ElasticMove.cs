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
				MonoBehaviour[] list = coll.gameObject.GetComponents<MonoBehaviour> ();
				foreach (MonoBehaviour mb in list) {
						if (mb is IEnemy) {
								IEnemy enemy = (IEnemy)mb;
								enemy.takeDamage(1);
								break;
						}
				}
				/*if (coll.gameObject.layer == 11) {
						Destroy (coll.gameObject);
						LintExplosion.Instance.Explosion (coll.gameObject.transform.position);
				}*/
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
