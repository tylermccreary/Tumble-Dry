using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
	
		private static Animator animator;
		private const string BOX_ANIM = "OpenBox";
	
		void Start ()
		{
				animator = GetComponent<Animator> ();
		}

		public static void openBox ()
		{
				animator.SetTrigger (BOX_ANIM);
		}
}
