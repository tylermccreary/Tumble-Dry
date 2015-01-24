using UnityEngine;
using System.Collections;

public class Crank : MonoBehaviour
{
		public LayerMask player;
		private bool pullCrank;
		private bool inRange;
		private float crankRadius;
		private Animator animator;
		private const string CRANK_BUTTON = "Fire2";
		private const string CRANK_ANIM = "turnCrank";

		void Start ()
		{
				crankRadius = transform.GetComponent<CircleCollider2D> ().radius;
				animator = GetComponent<Animator> ();
				pullCrank = false;
				inRange = false;
		}

		void Update ()
		{
				inRange = Physics2D.OverlapCircle (transform.position, crankRadius, player);
				pullCrank = Input.GetButton (CRANK_BUTTON);
				if (pullCrank && inRange) {
						triggerCrank ();
				}
		}

		void triggerCrank ()
		{
				animator.SetTrigger (CRANK_ANIM);
				Box.openBox ();
		}
}
