using UnityEngine;
using System.Collections;

public class ElasticCol : MonoBehaviour
{

		public LayerMask enemyLayer;
		private string enemy;

		void Awake ()
		{
				//enemy = LayerMask.LayerToName(enemyLayer);
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				if (coll.gameObject.layer == 11) {	//LayerMask.NameToLayer(enemy)){
						LintExplosion.Instance.Explosion (coll.gameObject.transform.position);
						Destroy (coll.gameObject);
				}
				if (coll.gameObject.layer != 8) {
						Destroy (gameObject);
						Shoot.changeElasticNum (-1);
				}
		}
}
