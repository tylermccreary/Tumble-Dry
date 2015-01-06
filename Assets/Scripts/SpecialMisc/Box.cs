using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
	
		private static Animator animator;

		// Use this for initialization
		void Start ()
		{
				animator = GetComponent<Animator> ();
		}

		public static void openBox ()
		{
				animator.SetTrigger ("OpenBox");
		}
}
