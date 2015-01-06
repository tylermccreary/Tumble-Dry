using UnityEngine;
using System.Collections;

public class Crank : MonoBehaviour
{

		private bool pullCrank;
		private bool inRange;
		private float crankRadius;
		public LayerMask player;
		private Animator animator;

		// Use this for initialization
		void Start ()
		{
				crankRadius = transform.GetComponent<CircleCollider2D> ().radius;
				animator = GetComponent<Animator> ();
				pullCrank = false;
				inRange = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				inRange = Physics2D.OverlapCircle (transform.position, crankRadius, player);
				pullCrank = Input.GetButton ("Fire2");
				if (pullCrank && inRange) {
						triggerCrank ();
				}
		}

		void triggerCrank ()
		{
				animator.SetTrigger ("turnCrank");
				Box.openBox ();
		}
}
