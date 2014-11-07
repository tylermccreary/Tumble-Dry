using UnityEngine;
using System.Collections;

public class StationaryUpDown : MonoBehaviour
{
		public bool goUp;
		public float distance;
		public float speed;

		IEnumerator Start ()
		{
		float interval = 10 / speed * distance;
				Vector2 pointB;
				if (goUp) {
						pointB = new Vector2 (transform.position.x, transform.position.y + distance);
				} else {
						pointB = new Vector2 (transform.position.x, transform.position.y - distance);
				}
				Vector2 pointA = transform.position;
				while (true) {
						yield return StartCoroutine (MoveObject (transform, pointA, pointB, interval));
						yield return StartCoroutine (MoveObject (transform, pointB, pointA, interval));

				}
		}

		IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
		{
				float i = 0.0f;
				float rate = 1.0f / time;
				while (i < 1.0f) {
						i += Time.deltaTime * rate;
						this.transform.position = Vector2.Lerp (startPos, endPos, i);
						yield return null;
				}
		}
}
