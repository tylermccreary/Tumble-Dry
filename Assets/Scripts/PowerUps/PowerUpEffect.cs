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
		private const string JUMP = "jump";
		private const string WATER = "water";
		private const string LIGHTNING = "lightning";
		private const string GROW = "grow";
	
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
				if (powerUp == JUMP) {
						effect = jumpEffect;
				} else if (powerUp == WATER) {
						effect = waterEffect;
				} else if (powerUp == LIGHTNING) {
						effect = lightningEffect;
				} else if (powerUp == GROW) {
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
