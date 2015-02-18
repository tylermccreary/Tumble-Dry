using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{
		public LayerMask player;
		private float finishRadius;
		private GameObject socky;
		private bool finish;
		private const string SOCK_COMPONENTS = "SockComponents";

		void Start ()
		{
				finishRadius = transform.GetComponent<CircleCollider2D> ().radius;
				socky = GameObject.Find (SOCK_COMPONENTS);
		}

		void Update ()
		{
				finish = Physics2D.OverlapCircle (transform.position, finishRadius, player);
				if (finish) {
						//End of level. Change Later
						Destroy (socky);
				}
		}

}
