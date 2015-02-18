using UnityEngine;
using System.Collections;

public class CoolDryer : MonoBehaviour
{
		private float waterRadius;
		public LayerMask player;
		private bool water;
		private const string WATER = "water";

		void Start ()
		{
				waterRadius = transform.GetComponent<CircleCollider2D> ().radius;
		}

		void Update ()
		{
				water = Physics2D.OverlapCircle (transform.position, waterRadius, player);
				if (water) {
						PowerUpEffect.Instance.Explosion (transform.position, WATER);
						Destroy (gameObject);
						Heat.resetHeat ();
				}
		}
}
