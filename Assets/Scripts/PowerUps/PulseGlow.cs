using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class PulseGlow : MonoBehaviour
{

		//private Light pointLight;
		public float pulseMinIntens = 5.0f;
		public float pulseMaxIntens = 8.0f;
		public float incMinIntens = 4.0f;
		public float incMaxIntens = 8.0f;
		private float minPulseVal;
		private float pulseMultiplier;
		private float time;
		public int speed;

		// Use this for initialization
		void Start ()
		{
				minPulseVal = 0.25f;
				time = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
				time = time + Time.deltaTime;
				if (gameObject.layer == 10) {
						pulse ();
				} else if (gameObject.layer == 13) {
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
