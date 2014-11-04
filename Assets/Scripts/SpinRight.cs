using UnityEngine;
using System.Collections;

public class SpinRight : MonoBehaviour
{

		public static readonly int speed = 10;

		// Update is called once per frame
		void FixedUpdate ()
		{
				transform.Rotate (Vector3.back * Time.deltaTime * speed);
		}
}
