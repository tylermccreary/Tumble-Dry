using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	
	private float finishRadius;
	public LayerMask player;
	GameObject socky;
	private bool finish;
	
	// Use this for initialization
	void Start () {
		finishRadius = transform.GetComponent<CircleCollider2D> ().radius;
		socky = GameObject.Find ("SockComponents");
	}
	
	// Update is called once per frame
	void Update () {
		finish = Physics2D.OverlapCircle (transform.position, finishRadius, player);
		if (finish) {
			Destroy(socky);
		}
	}

}
