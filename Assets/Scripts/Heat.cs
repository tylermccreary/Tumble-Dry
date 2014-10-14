using UnityEngine;
using System.Collections;

public class Heat : MonoBehaviour
{
		private SpriteRenderer heatRing;
		private static float heatFactor;
		private float heatRatio;
		private float maxHeat = 100f;
		private static float heat = 0.0f;
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
				hotg = 90f * 1f / 255f;
				hotb = 10f * 1f / 255f;
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

		public static float getHeat ()
		{
				return heat;
		}

		public static void resetHeat ()
		{
				heat = 0;
		}

		public static float getHeatFactor ()
		{
				return heatFactor;
		}
}
