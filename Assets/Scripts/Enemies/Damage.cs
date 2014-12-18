using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public int hp;

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.layer == 8) {
			SockyController.doDamage (hp);
		}
	}
}
