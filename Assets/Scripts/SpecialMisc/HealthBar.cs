using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
		public GameObject healthObject;
		private IHealthy healthy;
		private SpriteRenderer healthBar;
		private Vector3 healthScale;
		private Vector3 healthPosition;
		private float healthFactor;
		private float healthBarRatio;
		private int health;

		void Awake ()
		{
				MonoBehaviour[] list = gameObject.GetComponents<MonoBehaviour> ();
				foreach (MonoBehaviour mb in list) {
						if (mb is IHealthy) {
								healthy = (IHealthy)mb;
								health = healthy.getHealth ();
								;
								break;
						}
				}
				healthBar = healthObject.GetComponent<SpriteRenderer> ();
				healthScale = healthBar.transform.localScale;
				healthBarRatio = 1f / (health);
		}

		public void Update ()
		{
				UpdateHealthBar ();
				health = healthy.getHealth ();
				healthFactor = 1 - health * healthBarRatio;
		}

		private void UpdateHealthBar ()
		{
				healthBar.material.color = Color.Lerp (Color.green, Color.red, healthFactor);

				healthBar.transform.localScale = new Vector3 (healthScale.x * health * healthBarRatio, 1, 1);
		}
}
