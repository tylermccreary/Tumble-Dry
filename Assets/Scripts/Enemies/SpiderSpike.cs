using UnityEngine;
using System.Collections;

public class SpiderSpike : MonoBehaviour
{

		public float speed;
		private static GameObject lintSpider;

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
				if (coll.gameObject.layer == 8) {
						Destroy (gameObject);
						SockyController.doDamage (1);
				} else if (coll.gameObject.layer != 11) {
						Destroy (gameObject);
				}
		}
		
		public static void setSpiderObject (GameObject Spider)
		{
				lintSpider = Spider;
		}
}
