using UnityEngine;
using System.Collections;

public class Lint : MonoBehaviour
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
						damage ();
				}
		}

		void damage ()
		{
				Destroy (gameObject);
				SockyController.doDamage (1);
				LintExplosion.Instance.Explosion (transform.position);
		}
}
