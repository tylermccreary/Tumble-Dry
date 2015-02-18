using UnityEngine;

public class LintExplosion : MonoBehaviour
{
		public static LintExplosion Instance;
		public ParticleSystem smokeEffect;
	
		void Awake ()
		{
				Instance = this;
		}

		public void Explosion (Vector3 position)
		{
				instantiate (smokeEffect, position);
		}

		private ParticleSystem instantiate (ParticleSystem prefab, Vector3 position)
		{
				ParticleSystem newParticleSystem = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
				newParticleSystem.renderer.sortingLayerName = "Foreground";
				newParticleSystem.renderer.sortingOrder = 2;

				Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);
		
				return newParticleSystem;
		}
}
