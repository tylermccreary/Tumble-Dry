using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class PowerUpEffect : MonoBehaviour
{
		/// <summary>
		/// Singleton
		/// </summary>
		public static PowerUpEffect Instance;
		public ParticleSystem jumpEffect;
		public ParticleSystem waterEffect;
		public ParticleSystem lightningEffect;
		public ParticleSystem growEffect;
		public ParticleSystem shrinkEffect;
		
		private ParticleSystem effect;
	
		void Awake ()
		{
				// Register the singleton
				if (Instance != null) {
						//Debug.LogError("Multiple instances of SpecialEffectsHelper!");
				}
		
				Instance = this;
		}
	
		/// <summary>
		/// Create an explosion at the given location
		/// </summary>
		/// <param name="position"></param>
		public void Explosion (Vector3 position, string powerUp)
		{
				// Smoke on the water
				if (powerUp == "jump") {
						effect = jumpEffect;
				} else if (powerUp == "water") {
						effect = waterEffect;
				} else if (powerUp == "lightning") {
						effect = lightningEffect;
				} else if (powerUp == "grow") {
						effect = growEffect;
				} else {
						effect = shrinkEffect;
				}
				instantiate (effect, position);
		}
	
		/// <summary>
		/// Instantiate a Particle system from prefab
		/// </summary>
		/// <param name="prefab"></param>
		/// <returns></returns>
		private ParticleSystem instantiate (ParticleSystem prefab, Vector3 position)
		{
				ParticleSystem newParticleSystem = Instantiate (
			prefab,
			position,
			Quaternion.identity
				) as ParticleSystem;

				newParticleSystem.renderer.sortingLayerName = "Middleground";
				newParticleSystem.renderer.sortingOrder = 0;

		
				// Make sure it will be destroyed
				Destroy (
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
				);
		
				return newParticleSystem;
		}
}
