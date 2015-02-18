using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	public int hp;
	private LayerMask PLAYER_LAYER = 8;
	
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.layer == PLAYER_LAYER) {
			SockyController.doDamage (hp);
		}
	}
}