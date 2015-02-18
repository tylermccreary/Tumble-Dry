using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DryerHoles : MonoBehaviour
{
		public float Radius = 4.74f;
		public int NumPoints = 12;
		public float widden = 1.05f;
		float CurrentRadius = 0.0f;
		public bool done = true;
		private float x;
		private float y;
		private Vector3 pos;
		public GameObject holes;

		void Update ()
		{
				if (!Application.isPlaying && done == false) {
						if (CurrentRadius != Radius) {
								CreateCircle ();
								done = true;
						}
				}
		}

		void CreateCircle ()
		{
				for (int loop = 0; loop <= NumPoints; loop++) {
						float angle = (Mathf.PI * 2.0f / NumPoints) * loop;
						x = Mathf.Sin (angle) * Radius;
						y = Mathf.Cos (angle) * Radius;

						pos = new Vector3 (-x, -y, 0.0f);
						
						//Sprite was backwards.
						Instantiate (holes, pos, Quaternion.AngleAxis (90 - (180 * angle) / Mathf.PI, Vector3.forward));
				}
				CurrentRadius = Radius;
		}
}
