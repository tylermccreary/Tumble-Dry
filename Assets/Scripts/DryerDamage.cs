using UnityEngine;
using System.Collections;

public class DryerDamage : MonoBehaviour {

	static public float heatThreshold = 80f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.layer == 8)
		{
			if(Heat.heat >= heatThreshold)
			{
				SockyController.health -= 1;
			}
		}
	}
}
