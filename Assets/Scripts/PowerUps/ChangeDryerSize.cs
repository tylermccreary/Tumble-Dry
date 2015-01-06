using UnityEngine;
using System.Collections;

public class ChangeDryerSize : MonoBehaviour {
	
	private float powerUpRadius;
	public LayerMask player;
	public bool shrink;
	private bool change;
	public Animator animator;
	private static bool grown;
	private static bool shrunk;
	
	// Use this for initialization
	void Start () {
		powerUpRadius = transform.GetComponent<CircleCollider2D> ().radius;
		grown = false;
		shrunk = false;
	}
	
	// Update is called once per frame
	void Update () {
		change = Physics2D.OverlapCircle (transform.position, powerUpRadius, player);
		if (change) {
			Destroy (gameObject);
			if (shrink) {
				shrunk = true;
				if (grown) {
					grown = false;
					animator.SetTrigger("GrowToShrink");
				} else {
					animator.SetTrigger("Shrink");
				}
			} else {
				grown = true;
				if (shrunk) {
					shrunk = false;
					animator.SetTrigger("ShrinkToGrow");
				} else {
					animator.SetTrigger("Grow");
				}
			}
		}
	}
}