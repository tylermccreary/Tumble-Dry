using UnityEngine;
using System.Collections;

public class Shock : MonoBehaviour
{
	
		private float shockRadius;
		public LayerMask player;
		private bool shock;
		private GameObject enemy;
		private const string LIGHTNING = "lightning";
	
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
						//find and destroy all enemies
						object[] allEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
						foreach (object thisObject in allEnemies) {
								enemy = (GameObject)thisObject;
								LintExplosion.Instance.Explosion (enemy.gameObject.transform.position);
								Destroy (enemy);
						}
				
				}
		}
}