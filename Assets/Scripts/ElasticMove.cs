using UnityEngine;
using System.Collections;

public class ElasticMove : MonoBehaviour {

	private bool facingRight;
	public float shootingForce = 200f;
	private bool forceAdded = false;
	public LayerMask enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		facingRight = SockyController.facingRight;
		elasticForce ();
	}

	void elasticForce() {
		if (facingRight && !forceAdded) {
						transform.rigidbody2D.AddForce (new Vector2 (shootingForce, 0));
			forceAdded = true;
				} else if (!facingRight && !forceAdded) {
						transform.rigidbody2D.AddForce (new Vector2 (-1 * shootingForce, 0));
			forceAdded = true;
				}
	}
}
