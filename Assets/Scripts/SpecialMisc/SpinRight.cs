using UnityEngine;
using System.Collections;

public class SpinRight : MonoBehaviour
{

		public int speed;
		public bool right;
		private int speedActual;

		void Start ()
		{
				speedActual = 5 * speed;
		}

		// Update is called once per frame
		void FixedUpdate ()
		{
				if (right) {
						transform.Rotate (Vector3.back * Time.deltaTime * speedActual);
				} else {
						transform.Rotate (Vector3.forward * Time.deltaTime * speedActual);
				}
		}
}
