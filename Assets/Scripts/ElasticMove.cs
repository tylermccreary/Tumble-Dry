using UnityEngine;
using System.Collections;

public class ElasticMove : MonoBehaviour
{

		private bool faceRight;
		public float shootingForce = 200f;
		private bool forceAdded = false;
		public LayerMask enemy;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				facingRight ();
				elasticForce ();
		}

		void elasticForce ()
		{
				if (faceRight && !forceAdded) {
						transform.rigidbody2D.AddForce (new Vector2 (shootingForce, 0));
						forceAdded = true;
				} else if (!faceRight && !forceAdded) {
						transform.rigidbody2D.AddForce (new Vector2 (-1 * shootingForce, 0));
						forceAdded = true;
				}
		}

		void facingRight ()
		{
				faceRight = SockyController.isFacingRight ();
		}
}
