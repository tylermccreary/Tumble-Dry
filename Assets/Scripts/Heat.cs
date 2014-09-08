using UnityEngine;
using System.Collections;

public class Heat : MonoBehaviour
{
		private SpriteRenderer heatRing;
		private float heatFactor;
		private float heatRatio;
		private float maxHeat = 100f;
		static public float heat = 0.0f;
		private Color cool;
		private Color hot;
		private float coolr;
		private float coolg;
		private float coolb;
		private float hotr;
		private float hotg;
		private float hotb;

		void Awake ()
		{
				coolr = 220f * 1f / 255f;
				coolb = 220f * 1f / 255f;
				coolg = 220f * 1f / 255f;
				hotr = 255f * 1f / 255f;
				hotg = 100f * 1f / 255f;
				hotb = 20f * 1f / 255f;
				cool = (Color)new Vector4 (coolr, coolg, coolb, 1);
				hot = (Color)new Vector4 (hotr, hotg, hotb, 1);
				heatRing = transform.GetComponent<SpriteRenderer> ();
				heatRatio = 1f / maxHeat;
		}

		public void Update ()
		{
				UpdateHeatColor ();
				if (heat < maxHeat) {
						heat = heat + Time.deltaTime;
						heatFactor = heat * heatRatio;
				}
		}

		public void UpdateHeatColor ()
		{
				heatRing.material.color = Color.Lerp (cool, hot, heatFactor);
		}
}
