using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class PulseGlow : MonoBehaviour
{
		public int speed;
		public float pulseMinIntens = 5.0f;
		public float pulseMaxIntens = 8.0f;
		public float incMinIntens = 4.0f;
		public float incMaxIntens = 8.0f;
		private float minPulseVal = 0.25f;
		private float pulseMultiplier;
		private float time;
		private const int POWERUP_LAYER = 10;
		private const int DRYER_LAYER = 13;

		void Start ()
		{
				time = 0;
		}

		void Update ()
		{
				time = time + Time.deltaTime;
				if (gameObject.layer == POWERUP_LAYER) {
						pulse ();
				} else if (gameObject.layer == DRYER_LAYER) {
						increase ();
				}
		}

		void pulse ()
		{
				pulseMultiplier = Mathf.Sin (time * speed) * (1 - minPulseVal) + minPulseVal;
				light.intensity = Mathf.Lerp (pulseMinIntens, pulseMaxIntens, pulseMultiplier);
		}

		void increase ()
		{
				light.intensity = Mathf.Lerp (incMinIntens, incMaxIntens, Heat.getHeatFactor ());
		}
}
