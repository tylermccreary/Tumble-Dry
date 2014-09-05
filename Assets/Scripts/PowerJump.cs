using UnityEngine;
using System.Collections;

public class PowerJump : MonoBehaviour {

	private bool powerJump;
	private float powerJumpRadius;
	public LayerMask player;
	GameObject lint;

	// Use this for initialization
	void Start () 
	{
		powerJump = false;
		lint = GameObject.Find ("lint");
		powerJumpRadius = transform.GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () 
	{
		powerJump = Physics2D.OverlapCircle (transform.position, powerJumpRadius, player);
		if (powerJump) 
		{
			SockyController.jumpForce = SockyController.jumpForce * 2;
			Destroy (gameObject);
			powerJump = false;
			LintExplosion.Instance.Explosion (lint.transform.position);
			Destroy (lint);
		}
	}

}
