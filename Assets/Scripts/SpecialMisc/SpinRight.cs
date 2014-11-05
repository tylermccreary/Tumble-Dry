using UnityEngine;
using System.Collections;

public class SpinRight : MonoBehaviour
{

		public static readonly int speed = 10;
		public bool right;

		// Update is called once per frame
		void FixedUpdate ()
		{
				if (right) {
						transform.Rotate (Vector3.back * Time.deltaTime * speed);
				} else {
						transform.Rotate (Vector3.forward * Time.deltaTime * speed);
				}
		}
}
