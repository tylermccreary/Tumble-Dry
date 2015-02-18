using UnityEngine;
using System.Collections;

public class Shock : MonoBehaviour
{
		public LayerMask player;
		private float shockRadius;
		private bool shock;
		private GameObject enemy;
		private const string LIGHTNING = "lightning";
		private const string ENEMY_TAG = "Enemy";
	
		void Start ()
		{
				shockRadius = transform.GetComponent<CircleCollider2D> ().radius;
		}
	
		void Update ()
		{
				shock = Physics2D.OverlapCircle (transform.position, shockRadius, player);
				if (shock) {
						PowerUpEffect.Instance.Explosion (transform.position, LIGHTNING);
						Destroy (gameObject);
						object[] allEnemies = GameObject.FindGameObjectsWithTag (ENEMY_TAG);
						foreach (object thisObject in allEnemies) {
								enemy = (GameObject)thisObject;
								LintExplosion.Instance.Explosion (enemy.gameObject.transform.position);
								Destroy (enemy);
						}
				
				}
		}
}