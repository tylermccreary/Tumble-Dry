using UnityEngine;
using System.Collections;

public class SpiderSpike : MonoBehaviour
{

		public float speed;
		private static GameObject lintSpider;
		private const int PLAYER_LAYER = 8;
		private const int ENEMY_LAYER = 11;

		void Start ()
		{
				if (transform.position.x < lintSpider.transform.position.x) {
						transform.rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
						transform.localScale = -1 * transform.localScale;
				} else {
						transform.rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
				}
		}

		void OnTriggerEnter2D (Collider2D coll)
		{
				if (coll.gameObject.layer == PLAYER_LAYER) {
						Destroy (gameObject);
						SockyController.doDamage (1);
				} else if (coll.gameObject.layer != ENEMY_LAYER) {
						Destroy (gameObject);
				}
		}
		
		public static void setSpiderObject (GameObject Spider)
		{
				lintSpider = Spider;
		}
}
