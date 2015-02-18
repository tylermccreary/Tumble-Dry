using UnityEngine;
using System.Collections;

public class DryerDamage : MonoBehaviour
{

		public static float heatThreshold = 80f;
	private LayerMask PLAYER_LAYER = 8;

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.layer == PLAYER_LAYER) {
						if (Heat.getHeat () >= heatThreshold) {
								SockyController.doDamage (1);
						}
				}
		}
}
