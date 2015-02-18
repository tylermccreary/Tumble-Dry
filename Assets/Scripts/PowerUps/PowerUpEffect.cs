using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
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
				Instance = this;
		}

		public void Explosion (Vector3 position, string powerUp)
		{
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

		private ParticleSystem instantiate (ParticleSystem prefab, Vector3 position)
		{
				ParticleSystem newParticleSystem = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
				newParticleSystem.renderer.sortingLayerName = "Middleground";
				newParticleSystem.renderer.sortingOrder = 0;

				Destroy (newParticleSystem.gameObject, newParticleSystem.startLifetime);
		
				return newParticleSystem;
		}
}
