using UnityEngine;
using System.Collections;

public class Lint : MonoBehaviour, IEnemy
{
		private bool hit;
		private float lintRadius;
		public LayerMask player;


		// Use this for initialization
		void Start ()
		{
				lintRadius = transform.GetComponent<CircleCollider2D> ().radius;
		}

		void FixedUpdate ()
		{
				hit = Physics2D.OverlapCircle (transform.position, lintRadius, player);
				if (hit) {
						doDamage ();
						die ();
				}
		}

		public void takeDamage(int amount) {
				die ();
		}

		public void doDamage ()
		{
				SockyController.doDamage (1);				
		}

		public void die() {
				Destroy (gameObject);
				LintExplosion.Instance.Explosion (transform.position);
		}
		
		public string getType ()
		{
				return "lint";
		}
}
