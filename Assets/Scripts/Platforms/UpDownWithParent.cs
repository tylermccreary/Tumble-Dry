using UnityEngine;
using System.Collections;

public class UpDownWithParent : MonoBehaviour
{
		public bool goUp;
		public float distance;
		public float speed;
		Vector2 parentPos;
		Vector2 currentPos;
		Vector2 intercept;

		IEnumerator Start ()
		{
				intercept = new Vector2 (0, distance);
				currentPos = new Vector2 (transform.position.x, transform.position.y);
				parentPos = new Vector2 (transform.parent.position.x, transform.parent.position.y);
				float interval = (15 / speed) * distance;
				Vector2 pointB;
				Vector2 pointA = transform.position;
				while (true) {
						currentPos = new Vector2 (transform.position.x, transform.position.y);
						yield return StartCoroutine (MoveObject (true, interval));
						currentPos = new Vector2 (transform.position.x, transform.position.y);
						yield return StartCoroutine (MoveObject (false, interval));
				}
		}

		void Update ()
		{
				parentPos = new Vector2 (transform.parent.position.x, transform.parent.position.y);
		}

		IEnumerator MoveObject (bool up, float time)
		{
				float i = 0.0f;
				float rate = 1.0f / time;
				while (i < 1.0f) {
						i += Time.deltaTime * rate;
						if (goUp) {
								if (up) {
										transform.position = Vector2.Lerp (currentPos, parentPos + intercept / 2, i);
								} else {
										transform.position = Vector2.Lerp (currentPos, parentPos - intercept / 2, i);
								}
						} else {
								if (up) {
										transform.position = Vector2.Lerp (currentPos, parentPos - intercept / 2, i);
								} else {
										transform.position = Vector2.Lerp (currentPos, parentPos + intercept / 2, i);
								}
						}
						yield return null;
				}
		}
}
