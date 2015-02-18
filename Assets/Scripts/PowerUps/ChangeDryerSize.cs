﻿using UnityEngine;
using System.Collections;

public class ChangeDryerSize : MonoBehaviour
{
		private float powerUpRadius;
		public LayerMask player;
		public bool shrink;
		private bool change;
		public Animator animator;
		private static bool grown;
		private static bool shrunk;
		private const string SHRINK = "shrink";
		private const string GROW = "grow";
		private const string GTS_TRIGGER = "GrowToShrink";
		private const string SHRINK_TRIGGER = "Shrink";
		private const string STG_TRIGGER = "ShrinkToGrow";
		private const string GROW_TRIGGER = "Grow";

		void Start ()
		{
				powerUpRadius = transform.GetComponent<CircleCollider2D> ().radius;
				grown = false;
				shrunk = false;
		}

		void Update ()
		{
				change = Physics2D.OverlapCircle (transform.position, powerUpRadius, player);
				if (change) {
						Destroy (gameObject);
						if (shrink) {
								PowerUpEffect.Instance.Explosion (transform.position, SHRINK);
								shrunk = true;
								if (grown) {
										grown = false;
										animator.SetTrigger (GTS_TRIGGER);
								} else {
										animator.SetTrigger (SHRINK_TRIGGER);
								}
						} else {
								PowerUpEffect.Instance.Explosion (transform.position, GROW);
								grown = true;
								if (shrunk) {
										shrunk = false;
										animator.SetTrigger (STG_TRIGGER);
								} else {
										animator.SetTrigger (GROW_TRIGGER);
								}
						}
				}
		}
}