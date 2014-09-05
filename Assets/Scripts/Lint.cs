using UnityEngine;
using System.Collections;

public class Lint : MonoBehaviour {

	private bool hit;
	private float lintRadius;
	public LayerMask player;


	// Use this for initialization
	void Start () 
	{
		lintRadius = transform.GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		hit = Physics2D.OverlapCircle (transform.position, lintRadius, player);
		if(hit){
			damage();
		}
	}

	void damage()
	{
		Destroy (gameObject);
		SockyController.health = SockyController.health - 1;
		LintExplosion.Instance.Explosion(transform.position);
	}
}
