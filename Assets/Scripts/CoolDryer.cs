using UnityEngine;
using System.Collections;

public class CoolDryer : MonoBehaviour {
	
	private float waterRadius;
	public LayerMask player;
	private bool water;

	void Start()
	{
		waterRadius = transform.GetComponent<CircleCollider2D> ().radius;
	}

	void Update()
	{
		water = Physics2D.OverlapCircle (transform.position, waterRadius, player);
		if (water) 
		{
			Destroy(gameObject);
			Heat.heat = 0;
		}
	}
}
