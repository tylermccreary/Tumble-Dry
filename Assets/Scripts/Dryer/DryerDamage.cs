using UnityEngine;
using System.Collections;

public class DryerDamage : MonoBehaviour
{

		public static float heatThreshold = 80f;

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.layer == 8) {
						if (Heat.getHeat () >= heatThreshold) {
								SockyController.doDamage (1);
						}
				}
		}
}
