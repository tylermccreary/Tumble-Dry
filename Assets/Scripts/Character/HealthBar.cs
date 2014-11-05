﻿using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
		private SpriteRenderer healthBar;
		private Vector3 healthScale;
		private float healthFactor;
		private Vector3 healthPosition;
		public float healthBarRatio;

		void Awake ()
		{
				healthBar = GameObject.Find ("innerHealth").GetComponent<SpriteRenderer> ();
				healthScale = healthBar.transform.localScale;
				healthBarRatio = 1f / (SockyController.getHealth ());
		}

		public void Update ()
		{
				UpdateHealthBar ();
				healthFactor = 1 - SockyController.getHealth () * healthBarRatio;
		}

		public void UpdateHealthBar ()
		{
				// Set the health bar's colour to proportion of the way between green and red based on the player's health.
				healthBar.material.color = Color.Lerp (Color.green, Color.red, healthFactor);

				// Set the scale of the health bar to be proportional to the player's health.
				healthBar.transform.localScale = new Vector3 (healthScale.x * SockyController.getHealth () * healthBarRatio, 1, 1);
		}
}
